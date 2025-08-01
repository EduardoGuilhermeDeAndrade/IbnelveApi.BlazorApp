using System.Net.Http.Json;
using System.Text.Json;
using IbnelveApi.BlazorApp.Models;

namespace IbnelveApi.BlazorApp.Services;

public interface ITarefaService
{
    Task<ApiResponse<IEnumerable<TarefaDto>>> GetAllAsync(bool includeDeleted = false);
    Task<ApiResponse<IEnumerable<TarefaDto>>> GetWithFiltersAsync(TarefaFiltroDto filtro);
    Task<ApiResponse<TarefaDto>> GetByIdAsync(int id);
    Task<ApiResponse<IEnumerable<TarefaDto>>> SearchAsync(string searchTerm, bool includeDeleted = false);
    Task<ApiResponse<IEnumerable<TarefaDto>>> GetByStatusAsync(StatusTarefa status, bool includeDeleted = false);
    Task<ApiResponse<IEnumerable<TarefaDto>>> GetVencidasAsync(bool includeDeleted = false);
    Task<ApiResponse<IEnumerable<TarefaDto>>> GetConcluidasAsync(bool includeDeleted = false);
    Task<ApiResponse<TarefaDto>> CreateAsync(CreateTarefaDto tarefa);
    Task<ApiResponse<TarefaDto>> UpdateAsync(int id, UpdateTarefaDto tarefa);
    Task<ApiResponse<TarefaDto>> UpdateStatusAsync(int id, StatusTarefa status);
    Task<ApiResponse<TarefaDto>> MarcarComoConcluidaAsync(int id);
    Task<ApiResponse<TarefaDto>> MarcarComoPendenteAsync(int id);
    Task<ApiResponse> DeleteAsync(int id);
}

public class TarefaService : ITarefaService
{
    private readonly HttpClient _httpClient;

    public TarefaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<IEnumerable<TarefaDto>>> GetAllAsync(bool includeDeleted = false)
    {
        try
        {
            var url = $"api/tarefa?includeDeleted={includeDeleted}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<IEnumerable<TarefaDto>>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<IEnumerable<TarefaDto>> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<TarefaDto>> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<IEnumerable<TarefaDto>>> GetWithFiltersAsync(TarefaFiltroDto filtro)
    {
        try
        {
            var queryParams = new List<string>();
            
            if (filtro.Status.HasValue)
                queryParams.Add($"status={filtro.Status.Value}");
            if (filtro.Prioridade.HasValue)
                queryParams.Add($"prioridade={filtro.Prioridade.Value}");
            if (!string.IsNullOrEmpty(filtro.Categoria))
                queryParams.Add($"categoria={Uri.EscapeDataString(filtro.Categoria)}");
            if (filtro.DataVencimentoInicio.HasValue)
                queryParams.Add($"dataVencimentoInicio={filtro.DataVencimentoInicio.Value:yyyy-MM-dd}");
            if (filtro.DataVencimentoFim.HasValue)
                queryParams.Add($"dataVencimentoFim={filtro.DataVencimentoFim.Value:yyyy-MM-dd}");
            if (!string.IsNullOrEmpty(filtro.SearchTerm))
                queryParams.Add($"searchTerm={Uri.EscapeDataString(filtro.SearchTerm)}");
            
            queryParams.Add($"includeDeleted={filtro.IncludeDeleted}");
            queryParams.Add($"orderBy={filtro.OrderBy}");

            var url = $"api/tarefa/filtros?{string.Join("&", queryParams)}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<IEnumerable<TarefaDto>>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<IEnumerable<TarefaDto>> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<TarefaDto>> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<TarefaDto>> GetByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/tarefa/{id}");
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<TarefaDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<TarefaDto> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<TarefaDto> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<IEnumerable<TarefaDto>>> SearchAsync(string searchTerm, bool includeDeleted = false)
    {
        try
        {
            var url = $"api/tarefa/search?searchTerm={Uri.EscapeDataString(searchTerm)}&includeDeleted={includeDeleted}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<IEnumerable<TarefaDto>>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<IEnumerable<TarefaDto>> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<TarefaDto>> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<IEnumerable<TarefaDto>>> GetByStatusAsync(StatusTarefa status, bool includeDeleted = false)
    {
        try
        {
            var url = $"api/tarefa/status/{(int)status}?includeDeleted={includeDeleted}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<IEnumerable<TarefaDto>>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<IEnumerable<TarefaDto>> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<TarefaDto>> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<IEnumerable<TarefaDto>>> GetVencidasAsync(bool includeDeleted = false)
    {
        try
        {
            var url = $"api/tarefa/vencidas?includeDeleted={includeDeleted}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<IEnumerable<TarefaDto>>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<IEnumerable<TarefaDto>> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<TarefaDto>> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<IEnumerable<TarefaDto>>> GetConcluidasAsync(bool includeDeleted = false)
    {
        try
        {
            var url = $"api/tarefa/concluidas?includeDeleted={includeDeleted}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<IEnumerable<TarefaDto>>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<IEnumerable<TarefaDto>> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<TarefaDto>> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<TarefaDto>> CreateAsync(CreateTarefaDto tarefa)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/tarefa", tarefa);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<TarefaDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<TarefaDto> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<TarefaDto> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<TarefaDto>> UpdateAsync(int id, UpdateTarefaDto tarefa)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/tarefa/{id}", tarefa);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<TarefaDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<TarefaDto> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<TarefaDto> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<TarefaDto>> UpdateStatusAsync(int id, StatusTarefa status)
    {
        try
        {
            var request = new UpdateStatusTarefaDto { Status = status };
            var response = await _httpClient.PatchAsJsonAsync($"api/tarefa/{id}/status", request);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<TarefaDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<TarefaDto> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<TarefaDto> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<TarefaDto>> MarcarComoConcluidaAsync(int id)
    {
        try
        {
            var response = await _httpClient.PatchAsync($"api/tarefa/{id}/concluir", null);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<TarefaDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<TarefaDto> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<TarefaDto> 
            { 
                Success = false, 
                Message = "Erro de conexão", 
                Errors = new List<string> { ex.Message } 
            };
        }
    }

    public async Task<ApiResponse<TarefaDto>> MarcarComoPendenteAsync(int id)
    {
        try
        {
            var response = await _httpClient.PatchAsync($"api/tarefa/{id}/pendente", null);
            var content = await response.Content.ReadAsStringAsync();
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<TarefaDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse ?? new ApiResponse<TarefaDto> { Success = false, Message = "Resposta inválida" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<TarefaDto> 
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
            var response = await _httpClient.DeleteAsync($"api/tarefa/{id}");
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

