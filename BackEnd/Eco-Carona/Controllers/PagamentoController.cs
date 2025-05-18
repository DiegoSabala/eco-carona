using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Eco_Carona.Controllers;

public class PagamentoController
{
    public static void MapRoutes(WebApplication app)
    {
        app.MapPost("/pagamentos", async (Pagamento pagamento, AppDbContext db) =>
        {
            db.Pagamentos.Add(pagamento);
            await db.SaveChangesAsync();
            return Results.Created($"/pagamentos/{pagamento.Id}", pagamento);
        });

        app.MapGet("/pagamentos/{id}", async (int id, AppDbContext db) =>
            await db.Pagamentos.FindAsync(id) is Pagamento p ? Results.Ok(p) : Results.NotFound());

        app.MapGet("/pagamentos/viagem/{viagemId}", async (int viagemId, AppDbContext db) =>
        {
            var pagamentos = await db.Pagamentos.Where(p => p.ViagemId == viagemId).ToListAsync();
            return pagamentos.Any() ? Results.Ok(pagamentos) : Results.NotFound();
        });

        app.MapPost("/custos", async (CustoViagem custo, AppDbContext db) =>
        {
            db.CustosViagem.Add(custo);
            await db.SaveChangesAsync();
            return Results.Created($"/custos/{custo.ViagemId}", custo);
        });

        app.MapGet("/custos/{viagemId}", async (int viagemId, AppDbContext db, IMockDataService mockService) =>
        {
            var custo = await db.CustosViagem.FirstOrDefaultAsync(c => c.ViagemId == viagemId)
                        ?? mockService.GetFakeCustoViagem(viagemId);

            var custoPorPassageiro = custo.TotalPassageiros > 0
                ? custo.CustoTotal / custo.TotalPassageiros
                : 0;

            return Results.Ok(new
            {
                custo.ViagemId,
                custo.CustoTotal,
                custo.TotalPassageiros,
                CustoPorPassageiro = custoPorPassageiro,
                Mock = custo.Id == 0 // Se não veio do banco
            });
        });

        app.MapPost("/pagamentos/gerar/{viagemId}", async (int viagemId, AppDbContext db, IMockDataService mockService) =>
        {
            var custo = await db.CustosViagem.FirstOrDefaultAsync(c => c.ViagemId == viagemId);
            var reservasAceitas = await db.Reservas
                .Where(r => r.ViagemId == viagemId && r.Status == "Aceita")
                .ToListAsync();

            bool mock = false;

            if (custo is null)
            {
                custo = mockService.GetFakeCustoViagem(viagemId);
                mock = true;
            }

            if (!reservasAceitas.Any())
            {
                reservasAceitas = mockService.GetFakeReservasAceitas(viagemId, custo.TotalPassageiros);
                mock = true;
            }

            var valorIndividual = custo.CustoTotal / reservasAceitas.Count;

            var pagamentos = new List<Pagamento>();
            foreach (var reserva in reservasAceitas)
            {
                var pagamento = new Pagamento
                {
                    PassageiroId = reserva.PassageiroId,
                    ViagemId = viagemId,
                    Valor = valorIndividual,
                    Metodo = "Pix"
                };
                db.Pagamentos.Add(pagamento);
                pagamentos.Add(pagamento);
            }

            await db.SaveChangesAsync();
            return Results.Ok(new
            {
                ViagemId = viagemId,
                PassageirosPagos = pagamentos.Count,
                ValorPorPassageiro = valorIndividual,
                Mock = mock
            });
        });
    }
}
