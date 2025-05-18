namespace Domain.Entities;

public class Rota
{
    public int Id { get; set; }
    public int MotoristaId { get; set; }
    public string Origem { get; set; }
    public string Destino { get; set; }
    public string Horario { get; set; }
    public string DiasSemana { get; set; }

    public Veiculo Veiculo { get; set; }
}

