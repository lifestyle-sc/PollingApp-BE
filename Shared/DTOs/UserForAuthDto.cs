using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public record UserForAuthDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
}
