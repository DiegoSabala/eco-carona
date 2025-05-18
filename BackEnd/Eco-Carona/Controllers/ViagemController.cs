using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Eco_Carona.Controllers;

public class ViagemController
{
    public static void MapRoutes(WebApplication app)
    {
        app.MapPost("/viagens", async (Viagem viagem, AppDbContext db) =>
        {
            db.Viagens.Add(viagem);
            await db.SaveChangesAsync();
            return Results.Created($"/viagens/{viagem.Id}", viagem);
        });

        app.MapGet("/viagens", async (AppDbContext db) =>
            await db.Viagens.ToListAsync());
    }
}
