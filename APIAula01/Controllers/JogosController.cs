using APIAula01.Data;
using APIAula01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;   // necessário para o ToListAsync

namespace APIAula01.Controllers;

/// <summary>
/// Versão 2: os dados ficam num banco de dados, acessado pelo Entity Framework Core.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class JogosController : ControllerBase
{
    private readonly AppDbContext _context;

    // O ASP.NET entrega um AppDbContext novo a cada requisição (Scoped)
    public JogosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Jogos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Jogo>>> GetJogos()
    {
        return Ok(await _context.Jogos.ToListAsync());
    }

    // GET: api/Jogos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Jogo>> GetJogo(int id)
    {
        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo is null)
        {
            return NotFound();
        }

        return Ok(jogo);
    }

    // POST: api/Jogos
    [HttpPost]
    public async Task<ActionResult<Jogo>> PostJogo(Jogo jogo)
    {
        jogo.Id = 0;                    // quem gera o Id é o banco

        _context.Jogos.Add(jogo);
        await _context.SaveChangesAsync();

        // 201 Created + cabeçalho Location apontando para GET api/Jogos/{id}
        return CreatedAtAction(nameof(GetJogo), new { id = jogo.Id }, jogo);
    }

    // PUT: api/Jogos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutJogo(int id, Jogo jogoAtualizado)
    {
        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo is null)
        {
            return NotFound();
        }

        jogo.Titulo = jogoAtualizado.Titulo;
        jogo.Genero = jogoAtualizado.Genero;
        jogo.Plataforma = jogoAtualizado.Plataforma;
        jogo.AnoLancamento = jogoAtualizado.AnoLancamento;
        jogo.Zerado = jogoAtualizado.Zerado;
        jogo.Nota = jogoAtualizado.Nota;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Jogos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJogo(int id)
    {
        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo is null)
        {
            return NotFound();
        }

        _context.Jogos.Remove(jogo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
