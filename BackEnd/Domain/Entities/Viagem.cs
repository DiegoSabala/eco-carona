namespace Domain.Entities;

public class Viagem
{
    public int Id { get; set; }
    public int MotoristaId { get; set; }
    public string Origem { get; set; }
    public string Destino { get; set; }
    public DateTime Data { get; set; }
    public string Horario { get; set; }
    public int VagasDisponiveis { get; set; }
    public decimal CustoEstimado { get; set; }
}
