using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Poll>? Polls { get; set; }
    }
}
