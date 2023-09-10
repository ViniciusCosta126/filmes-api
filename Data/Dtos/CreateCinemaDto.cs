using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O campo nome é obrigatorio")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Id do cinema é obrigatorio")]
    public int EnderecoId { get; set; }
}