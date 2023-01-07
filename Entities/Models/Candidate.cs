using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Candidate : BaseEntity
    {
        [Column("CandidateId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name of poll item is a required field.")]
        public string? Name { get; set;}
        public int Count { get; set; }

        [ForeignKey(nameof(Poll))]
        public Guid PollId { get; set; }
        public Poll? Poll { get; set; }
    }
}
