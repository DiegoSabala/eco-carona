using Bogus;
using Domain.Entities;

namespace Infrastructure.Database;

public class MockDataService : IMockDataService
{
    public Usuario GenerateFakeUsuario(int id)
    {
        var faker = new Faker<Usuario>()
            .RuleFor(u => u.Id, id)
            .RuleFor(u => u.Nome, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email());

        return faker.Generate();
    }

    public Veiculo GenerateFakeVeiculo(int id)
    {
        var faker = new Faker<Veiculo>()
            .RuleFor(v => v.Id, id)
            .RuleFor(v => v.UsuarioId, f => f.Random.Int(1, 100))
            .RuleFor(v => v.Modelo, f => f.Vehicle.Model())
            .RuleFor(v => v.Placa, f => f.Random.AlphaNumeric(7).ToUpper())
            .RuleFor(v => v.Vagas, f => f.Random.Int(1, 5))
            .RuleFor(v => v.ConsumoMedio, f => f.Random.Double(8, 15));

        return faker.Generate();
    }

    public Rota GenerateFakeRota(int id)
    {
        var faker = new Faker<Rota>()
            .RuleFor(r => r.Id, id)
            .RuleFor(r => r.MotoristaId, f => f.Random.Int(1, 100))
            .RuleFor(r => r.Origem, f => f.Address.City())
            .RuleFor(r => r.Destino, f => f.Address.City())
            .RuleFor(r => r.Horario, f => f.Date.Future().ToShortTimeString())
            .RuleFor(r => r.DiasSemana, f => "Segunda, Quarta, Sexta");

        return faker.Generate();
    }

    public Viagem GenerateFakeViagem(int id)
    {
        var faker = new Faker<Viagem>()
            .RuleFor(v => v.Id, id)
            .RuleFor(v => v.MotoristaId, f => f.Random.Int(1, 100))
            .RuleFor(v => v.Origem, f => f.Address.City())
            .RuleFor(v => v.Destino, f => f.Address.City())
            .RuleFor(v => v.Data, f => f.Date.Future())
            .RuleFor(v => v.Horario, f => f.Date.Future().ToShortTimeString())
            .RuleFor(v => v.VagasDisponiveis, f => f.Random.Int(1, 4))
            .RuleFor(v => v.CustoEstimado, f => Math.Round(f.Random.Decimal(10, 50), 2));

        return faker.Generate();
    }

    public Reserva GenerateFakeReserva(int id)
    {
        var faker = new Faker<Reserva>()
            .RuleFor(r => r.Id, id)
            .RuleFor(r => r.PassageiroId, f => f.Random.Int(1, 100))
            .RuleFor(r => r.ViagemId, f => f.Random.Bool() ? f.Random.Int(1, 100) : null)
            .RuleFor(r => r.RotaId, f => f.Random.Bool() ? f.Random.Int(1, 100) : null)
            .RuleFor(r => r.Status, f => f.PickRandom(new[] { "Pendente", "Aceita", "Recusada" }));

        return faker.Generate();
    }

    public Avaliacao GenerateFakeAvaliacao(int id)
    {
        var faker = new Faker<Avaliacao>()
            .RuleFor(a => a.Id, id)
            .RuleFor(a => a.AvaliadorId, f => f.Random.Int(1, 100))
            .RuleFor(a => a.AvaliadoId, f => f.Random.Int(1, 100))
            .RuleFor(a => a.Nota, f => f.Random.Int(1, 5))
            .RuleFor(a => a.Comentario, f => f.Lorem.Sentence())
            .RuleFor(a => a.Tipo, f => f.PickRandom(new[] { "motorista", "passageiro" }));

        return faker.Generate();
    }

    public CustoViagem GetFakeCustoViagem(int viagemId)
    {
        var faker = new Faker("pt_BR");
        return new CustoViagem
        {
            ViagemId = viagemId,
            CustoTotal = faker.Random.Decimal(50, 200),
            TotalPassageiros = faker.Random.Int(2, 6)
        };
    }
    public List<Reserva> GetFakeReservasAceitas(int viagemId, int quantidade)
    {
        return new Faker<Reserva>("pt_BR")
            .RuleFor(r => r.ViagemId, viagemId)
            .RuleFor(r => r.PassageiroId, f => f.Random.Int(1, 1000))
            .RuleFor(r => r.Status, "Aceita")
            .Generate(quantidade);
    }
}