using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.JSInterop;
using IbnelveApi.BlazorApp.Models;

namespace IbnelveApi.BlazorApp.Services;

public interface IAuthService
{
    Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request);
    Task<ApiResponse> RegisterAsync(RegisterRequest request);
    Task LogoutAsync();
    Task<UserInfo> GetCurrentUserAsync();
    Task<bool> IsAuthenticatedAsync();
    Task<string?> GetTokenAsync();
}

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;
    private UserInfo _currentUser = new();

    public AuthService(HttpClient httpClient, IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
    }

    public async Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", request);
            var content = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<LoginResponse>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (apiResponse?.Success == true && apiResponse.Data != null)
                {
                    // Salvar token no localStorage
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", apiResponse.Data.Token);
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "userEmail", apiResponse.Data.Email);
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "tenantId", apiResponse.Data.TenantId);
                    
                    // Configurar header de autorização
                    _httpClient.DefaultRequestHeaders.Authorization = 
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiResponse.Data.Token);
                    
                    // Atualizar usuário atual
                    _currentUser = new UserInfo
                    {
                        Email = apiResponse.Data.Email,
                        TenantId = apiResponse.Data.TenantId,
                        IsAuthenticated = true
                    };
                }

                return apiResponse ?? new ApiResponse<LoginResponse> { Success = false, Message = "Resposta inválida" };
            }
            else
            {
                var errorResponse = JsonSerializer.Deserialize<ApiResponse<LoginResponse>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return errorResponse ?? new ApiResponse<LoginResponse> { Success = false, Message = "Erro na autenticação" };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<LoginResponse> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse> RegisterAsync(RegisterRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", request);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task LogoutAsync()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "userEmail");
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "tenantId");
        
        _httpClient.DefaultRequestHeaders.Authorization = null;
        _currentUser = new UserInfo();
    }

    public async Task<UserInfo> GetCurrentUserAsync()
    {
        if (_currentUser.IsAuthenticated)
            return _currentUser;

        var token = await GetTokenAsync();
        if (!string.IsNullOrEmpty(token))
        {
            var email = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "userEmail");
            var tenantId = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "tenantId");
            
            _currentUser = new UserInfo
            {
                Email = email ?? "",
                TenantId = tenantId ?? "",
                IsAuthenticated = true
            };
            
            _httpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        return _currentUser;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var token = await GetTokenAsync();
        return !string.IsNullOrEmpty(token);
    }

    public async Task<string?> GetTokenAsync()
    {
        try
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
        }
        catch
        {
            return null;
        }
    }
}

