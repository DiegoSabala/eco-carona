namespace Domain.Entities;
public class Reserva
{
    public int Id { get; set; }
    public int PassageiroId { get; set; }
    public int? ViagemId { get; set; }
    public int? RotaId { get; set; }
    public string Status { get; set; } = "Pendente";
}
