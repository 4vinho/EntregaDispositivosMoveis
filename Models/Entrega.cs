namespace EntregaDispositivosMoveis.Models;

public class Entrega
{
    public int Id { get; set; }
    public string Colaborador { get; set; } = string.Empty;
    public string Dispositivo { get; set; } = string.Empty;
    public DateTime DataEntrega { get; set; } = DateTime.UtcNow;
    public string? Observacoes { get; set; }
}
