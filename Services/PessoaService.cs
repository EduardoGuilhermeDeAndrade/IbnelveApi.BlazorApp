using System.Net.Http.Json;
using System.Text.Json;
using IbnelveApi.BlazorApp.Models;

namespace IbnelveApi.BlazorApp.Services;

public interface IPessoaService
{
    Task<ApiResponse<IEnumerable<PessoaDto>>> GetAllAsync(bool includeDeleted = false);
    Task<ApiResponse<PessoaDto>> GetByIdAsync(int id);
    Task<ApiResponse<PessoaDto>> GetByCpfAsync(string cpf);
    Task<ApiResponse<IEnumerable<PessoaDto>>> SearchByNameAsync(string nome, bool includeDeleted = false);
    Task<ApiResponse<PessoaDto>> CreateAsync(CreatePessoaDto pessoa);
    Task<ApiResponse<PessoaDto>> UpdateAsync(int id, UpdatePessoaDto pessoa);
    Task<ApiResponse> DeleteAsync(int id);
}

public class PessoaService : IPessoaService
{
    private readonly HttpClient _httpClient;

    public PessoaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<IEnumerable<PessoaDto>>> GetAllAsync(bool includeDeleted = false)
    {
        try
        {
            var url = $"api/pessoa?includeDeleted={includeDeleted}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<IEnumerable<PessoaDto>>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<IEnumerable<PessoaDto>> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<PessoaDto>> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<PessoaDto>> GetByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/pessoa/{id}");
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<PessoaDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<PessoaDto> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<PessoaDto> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<PessoaDto>> GetByCpfAsync(string cpf)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/pessoa/cpf/{cpf}");
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<PessoaDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<PessoaDto> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<PessoaDto> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<IEnumerable<PessoaDto>>> SearchByNameAsync(string nome, bool includeDeleted = false)
    {
        try
        {
            var url = $"api/pessoa/nome/{Uri.EscapeDataString(nome)}";
            //var url = $"api/pessoa/search?nome={Uri.EscapeDataString(nome)}&includeDeleted={includeDeleted}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<IEnumerable<PessoaDto>>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<IEnumerable<PessoaDto>> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<PessoaDto>> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<PessoaDto>> CreateAsync(CreatePessoaDto pessoa)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/pessoa", pessoa);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<PessoaDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<PessoaDto> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<PessoaDto> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<PessoaDto>> UpdateAsync(int id, UpdatePessoaDto pessoa)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/pessoa/{id}", pessoa);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<PessoaDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<PessoaDto> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<PessoaDto> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse> DeleteAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/pessoa/{id}");
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
}

