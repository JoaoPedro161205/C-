using System.ComponentModel.DataAnnotations;

namespace APIAula01.Models;

/// <summary>
/// Representa um jogo (videogame) do catálogo.
/// </summary>
public class Jogo
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O título é obrigatório.")]
    public string Titulo { get; set; } = string.Empty;

    public string Genero { get; set; } = string.Empty;

    public string Plataforma { get; set; } = string.Empty;

    [Range(1970, 2100, ErrorMessage = "Ano de lançamento inválido.")]
    public int AnoLancamento { get; set; }

    /// <summary>Indica se o jogo já foi zerado (concluído).</summary>
    public bool Zerado { get; set; }

    /// <summary>Nota de 0 a 10 dada ao jogo. Opcional.</summary>
    [Range(0, 10, ErrorMessage = "A nota deve estar entre 0 e 10.")]
    public int? Nota { get; set; }
}
