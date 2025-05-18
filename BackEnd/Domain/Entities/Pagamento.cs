namespace Domain.Entities;

public class Pagamento
{
    public int Id { get; set; }
    public int PassageiroId { get; set; }
    public int ViagemId { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataPagamento { get; set; } = DateTime.UtcNow;
    public string Metodo { get; set; } = "Pix";
}
