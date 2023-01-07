using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Poll : BaseEntity
    {
        [Column("PollId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name of Poll is a required field.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Deadline is a required field")]
        public DateTime Deadline { get; set; }

        public bool IsDisabled { get; set; }

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Candidate>? Candidates { get; set; }
    }
}
