using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public abstract record PollForManipulationDto : IValidatableObject
    {
        [Required(ErrorMessage = "Name of poll is a required field.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Deadline of poll is a requried field.")]
        public DateTime Deadline { get; init; }
        public bool IsDisabled { get; init; }
        public IEnumerable<CandidateForCreationDto>? Candidates { get; init; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errorMessage = $"The deadline set by the client is in the past.";
            if (Deadline <= DateTime.Now && !IsDisabled)
                yield return new ValidationResult(errorMessage, new[] { nameof(Deadline) });
        }
    }
}
