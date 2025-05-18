using Domain.Entities;
using Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Veiculo> Veiculos => Set<Veiculo>();
    public DbSet<Rota> Rotas => Set<Rota>();
    public DbSet<Viagem> Viagens => Set<Viagem>();
    public DbSet<Reserva> Reservas => Set<Reserva>();
    public DbSet<Avaliacao> Avaliacoes => Set<Avaliacao>();
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<CustoViagem> CustosViagem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
        modelBuilder.ApplyConfiguration(new RotaConfiguration());
        modelBuilder.ApplyConfiguration(new ViagemConfiguration());
        modelBuilder.ApplyConfiguration(new ReservaConfiguration());
        modelBuilder.ApplyConfiguration(new PagamentoConfiguration());
        modelBuilder.ApplyConfiguration(new AvaliacaoConfiguration());
    }
}
