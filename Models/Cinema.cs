using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo nome é obrigatorio")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Id do cinema é obrigatorio")]
    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }
}