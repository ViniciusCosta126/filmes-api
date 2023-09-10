using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Logradouro não pode ser vazio")]
    public string Logradouro { get; set; }
    [Required(ErrorMessage = "Numero não pode ser vazio!")]
    public int Numero { get; set; }
}