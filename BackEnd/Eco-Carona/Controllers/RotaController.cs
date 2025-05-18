using Domain.Entities;
using Infrastructure.Database;

namespace Eco_Carona.Controllers;

public class RotaController
{
    public static void MapRoutes(WebApplication app)
    {
        app.MapPost("/rotas", async (Rota rota, AppDbContext db) =>
        {
            db.Rotas.Add(rota);
            await db.SaveChangesAsync();
            return Results.Created($"/rotas/{rota.Id}", rota);
        });
    }
}
