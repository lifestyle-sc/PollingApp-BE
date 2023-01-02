using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Poll>? Polls { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
    }
}
