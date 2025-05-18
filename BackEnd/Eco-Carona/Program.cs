using Eco_Carona.Controllers;
using Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);

// Adicione a injeção para sua classe de mock, se usar
builder.Services.AddScoped<IMockDataService, MockDataService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

AvaliacaoController.MapRoutes(app);
PagamentoController.MapRoutes(app);
ReservaController.MapRoutes(app);
RotaController.MapRoutes(app);
UserController.MapRoutes(app);
VeiculoController.MapRoutes(app);
ViagemController.MapRoutes(app);

app.Run();
