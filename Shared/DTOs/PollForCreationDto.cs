using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public record PollForCreationDto
    {
        [Required(ErrorMessage = "Name of poll is a required field.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Deadline of poll is a requried field.")]
        public DateTime Deadline { get; init; }
        public bool IsDisabled { get; init; }
    }
}
