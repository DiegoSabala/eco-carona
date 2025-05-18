using Domain.Entities;
using Infrastructure.Database;

namespace Eco_Carona.Controllers;

public static class VeiculoController
{
    public static void MapRoutes(WebApplication app)
    {
        app.MapPost("/veiculos", async (Veiculo veiculo, AppDbContext db) =>
        {
            db.Veiculos.Add(veiculo);
            await db.SaveChangesAsync();
            return Results.Created($"/veiculos/{veiculo.Id}", veiculo);
        });

        app.MapGet("/veiculos/{id}", async (int id, AppDbContext db) =>
            await db.Veiculos.FindAsync(id) is Veiculo v ? Results.Ok(v) : Results.NotFound());

    }
}
