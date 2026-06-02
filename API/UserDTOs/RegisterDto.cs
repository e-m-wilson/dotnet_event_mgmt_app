using System.ComponentModel.DataAnnotations;

namespace API;

public class RegisterDto
{
    [Required, MinLength(3), MaxLength(50)]
    public string? DisplayName { get; set; }
    [Required, EmailAddress, MaxLength(50)]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}