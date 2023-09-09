using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O Titulo do filme é obrigatorio")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O Genero do filme é obrigatorio")]
    [MaxLength(50, ErrorMessage = "O tamanho do genero nao pode exceder 50 caracteres")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "O campo duração é obrigatorio")]
    [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
    public int Duracao { get; set; }
}