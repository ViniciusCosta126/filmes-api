using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class UpdateEnderecoDto
{
    [Required(ErrorMessage = "Logradouro não pode ser vazio")]
    public string Logradouro { get; set; }
    [Required(ErrorMessage = "Numero não pode ser vazio!")]
    public int Numero { get; set; }
}