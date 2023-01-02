namespace Entities.Models
{
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Poll>? Polls { get; set; }
    }
}
