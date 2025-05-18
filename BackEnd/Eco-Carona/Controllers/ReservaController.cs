using Domain.Entities;
using Infrastructure.Database;

namespace Eco_Carona.Controllers;

public class ReservaController
{
    public static void MapRoutes(WebApplication app)
    {
        app.MapPost("/reservas", async (Reserva reserva, AppDbContext db) =>
        {
            db.Reservas.Add(reserva);
            await db.SaveChangesAsync();
            return Results.Created($"/reservas/{reserva.Id}", reserva);
        });
    }
}
