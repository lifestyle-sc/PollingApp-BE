using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Poll
    {
        [Column("PollId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Deadline is a required field")]
        public DateTime Deadline { get; set; }

        public bool IsDisabled { get; set; } = false;

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Candidate>? Candidates { get; set; }
    }
}
