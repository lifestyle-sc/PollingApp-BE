namespace Shared.DTOs
{
    public record CandidateDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public int Count { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
