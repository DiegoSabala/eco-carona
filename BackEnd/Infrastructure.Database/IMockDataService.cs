using Domain.Entities;

namespace Infrastructure.Database;

public interface IMockDataService
{
    Usuario GenerateFakeUsuario(int id);
    Veiculo GenerateFakeVeiculo(int id);
    Rota GenerateFakeRota(int id);
    Viagem GenerateFakeViagem(int id);
    Reserva GenerateFakeReserva(int id);
    Avaliacao GenerateFakeAvaliacao(int id);
    CustoViagem GetFakeCustoViagem(int viagemId);
    List<Reserva> GetFakeReservasAceitas(int viagemId, int quantidade);
}