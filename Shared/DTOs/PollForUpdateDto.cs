using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public record PollForUpdateDto
    {
        [Required(ErrorMessage = "The Name of poll is a required field.")]
        public string? Name { get; init; }
        public DateTime Deadline { get; init; }
        public bool IsDisabled { get; init; }
        public IEnumerable<CandidateForCreationDto>? Candidates { get; init; }
    }
}
