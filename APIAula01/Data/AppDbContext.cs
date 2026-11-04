using APIAula01.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAula01.Data;

/// <summary>
/// A "porta" da API para o banco de dados.
/// </summary>
public class AppDbContext : DbContext
{
    // As opções (qual banco usar e onde ele está) vêm do Program.cs
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Cada DbSet vira uma tabela no banco.
    // Use como se fosse a antiga List<Jogo> do controller.
    public DbSet<Jogo> Jogos => Set<Jogo>();

    // Configurações do modelo. Aqui, os jogos que todo banco novo já deve ter.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Jogo>().HasData(
            new Jogo { Id = 1, Titulo = "The Legend of Zelda: Tears of the Kingdom", Genero = "Aventura", Plataforma = "Nintendo Switch", AnoLancamento = 2023, Zerado = true },
            new Jogo { Id = 2, Titulo = "Hollow Knight: Silksong", Genero = "Metroidvania", Plataforma = "PC", AnoLancamento = 2025, Zerado = false },
            new Jogo { Id = 3, Titulo = "EA Sports FC 26", Genero = "Esporte", Plataforma = "PlayStation 5", AnoLancamento = 2025, Zerado = false }
        );
    }
}
