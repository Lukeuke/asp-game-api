using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class Player
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(10, ErrorMessage = "Max amount of characters is 10")]
    public string Name { get; set; }

    public string Password { get; set; }
}