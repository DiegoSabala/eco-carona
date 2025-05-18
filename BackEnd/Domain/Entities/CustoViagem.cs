namespace Domain.Entities;
public class CustoViagem
{
    public int Id { get; set; }
    public int ViagemId { get; set; }
    public decimal CustoTotal { get; set; }
    public int TotalPassageiros { get; set; }
}
