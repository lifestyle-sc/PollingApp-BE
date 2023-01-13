namespace Shared.DTOs
{
    public record PollDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public DateTime Deadline { get; init; }
        public bool IsDisabled { get; init; }     
    }
}
