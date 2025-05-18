namespace Domain.Entities;

public class Veiculo
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string Modelo { get; set; }
    public string Placa { get; set; }
    public int Vagas { get; set; }
    public double ConsumoMedio { get; set; }

    public Usuario Usuario { get; set; }
}
