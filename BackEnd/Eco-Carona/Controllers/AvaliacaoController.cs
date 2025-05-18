using Infrastructure.Database;

namespace Eco_Carona.Controllers;

public class AvaliacaoController
{
    public static void MapRoutes(WebApplication app)
    {
        app.MapGet("/avaliacoes/{id}", async (int id, AppDbContext db, IMockDataService mock) =>
        {
            var avaliacao = await db.Avaliacoes.FindAsync(id);
            if (avaliacao is not null) return Results.Ok(avaliacao);

            var fake = mock.GenerateFakeAvaliacao(id);
            return Results.Ok(fake);
        });
    }
}
