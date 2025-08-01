namespace IbnelveApi.BlazorApp.Models;

public enum StatusTarefa
{
    Pendente = 1,
    EmAndamento = 2,
    Concluida = 3,
    Cancelada = 4
}

public enum PrioridadeTarefa
{
    Baixa = 1,
    Media = 2,
    Alta = 3,
    Critica = 4
}

public class TarefaDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public StatusTarefa Status { get; set; }
    public string StatusDescricao { get; set; } = string.Empty;
    public PrioridadeTarefa Prioridade { get; set; }
    public string PrioridadeDescricao { get; set; } = string.Empty;
    public DateTime? DataVencimento { get; set; }
    public DateTime? DataConclusao { get; set; }
    public string? Categoria { get; set; }
    public string TenantId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool EstaVencida { get; set; }
    public bool EstaConcluida { get; set; }
}

public class CreateTarefaDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public PrioridadeTarefa Prioridade { get; set; } = PrioridadeTarefa.Media;
    public DateTime? DataVencimento { get; set; }
    public string? Categoria { get; set; }
    public StatusTarefa Status { get; set; }
}

public class UpdateTarefaDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public PrioridadeTarefa Prioridade { get; set; }
    public DateTime? DataVencimento { get; set; }
    public string? Categoria { get; set; }
    public StatusTarefa Status { get; set; }
}

public class UpdateStatusTarefaDto
{
    public StatusTarefa Status { get; set; }
}

public class TarefaFiltroDto
{
    public StatusTarefa? Status { get; set; }
    public PrioridadeTarefa? Prioridade { get; set; }
    public string? Categoria { get; set; }
    public DateTime? DataVencimentoInicio { get; set; }
    public DateTime? DataVencimentoFim { get; set; }
    public bool IncludeDeleted { get; set; } = false;
    public string OrderBy { get; set; } = "CreatedAt";
    public string? SearchTerm { get; set; }
}

