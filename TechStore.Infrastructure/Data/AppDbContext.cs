using Microsoft.EntityFrameworkCore;
using TechStore.Domain.Entities;

namespace TechStore.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>()
            .ToTable("Cliente_tb", "Cliente")
            .HasKey(c => c.IdCliente);

        modelBuilder.Entity<Endereco>()
            .ToTable("Endereco_tb", "Cliente");

        modelBuilder.Entity<Categoria>()
            .ToTable("Categoria_tb", "Catalogo");

        modelBuilder.Entity<Produto>()
            .ToTable("Produto_tb", "Catalogo");

        base.OnModelCreating(modelBuilder);
    }

}
