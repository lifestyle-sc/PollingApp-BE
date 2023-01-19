using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public record CandidateForUpdateDto
    {
        [Required(ErrorMessage = "Name of candidate is a required field.")]
        public string? Name { get; init; }
        public int Count { get; init; }
    }
}
