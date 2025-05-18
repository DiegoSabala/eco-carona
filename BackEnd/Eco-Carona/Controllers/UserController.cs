using Domain.Entities;
using Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;

namespace Eco_Carona.Controllers;

[Route("api/[controller]")]
[ApiController]
public static class UserController
{
    public static void MapRoutes(WebApplication app)
    {
        app.MapPost("/usuarios", async (Usuario usuario, AppDbContext db) =>
        {
            db.Usuarios.Add(usuario);
            await db.SaveChangesAsync();
            return Results.Created($"/usuarios/{usuario.Id}", usuario);
        });

        app.MapGet("/usuarios/{id}", async (int id, AppDbContext db, IMockDataService mockData) =>
        {
            var usuario = await db.Usuarios.FindAsync(id);
            if (usuario != null) return Results.Ok(usuario);

            var usuarioFake = mockData.GenerateFakeUsuario(id);
            return Results.Ok(usuarioFake);
        });

        app.MapPut("/usuarios/{id}", async (int id, Usuario updated, AppDbContext db, IMockDataService mockData) =>
        {
            var user = await db.Usuarios.FindAsync(id);
            if (user is null)
            {
                var usuarioFake = mockData.GenerateFakeUsuario(id);
                return Results.Ok(usuarioFake);
            }

            user.Nome = updated.Nome;
            user.Email = updated.Email;

            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
