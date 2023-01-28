using Entities.Models;
using Repository.Extensions.Utilities;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

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

        public static IQueryable<Candidate> Sort(this IQueryable<Candidate> candidates, string orderbyQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderbyQueryString))
                return candidates.OrderBy(c => c.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Candidate>(orderbyQueryString);

            if(string.IsNullOrWhiteSpace(orderQuery))
                return candidates.OrderBy(c => c.Name);

            return candidates.OrderBy(orderQuery);
        }
    }
}
