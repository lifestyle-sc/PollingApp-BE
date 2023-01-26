using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public abstract record CandidateForManipulationDto
    {
        [Required(ErrorMessage = "Name of candidate is a required field.")]
        public string? Name { get; init; }
        public int Count { get; init; }
    }
}
