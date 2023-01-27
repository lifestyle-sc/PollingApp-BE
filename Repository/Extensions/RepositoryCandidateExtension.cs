using Entities.Models;

namespace Repository.Extensions
{
    public static class RepositoryCandidateExtension
    {
        public static IQueryable<Candidate> Search(this IQueryable<Candidate> candidates, string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
                return candidates;

            var lowerTerm = searchTerm.Trim().ToLower();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return candidates.Where(candidate => candidate.Name.ToLower().Contains(lowerTerm));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
