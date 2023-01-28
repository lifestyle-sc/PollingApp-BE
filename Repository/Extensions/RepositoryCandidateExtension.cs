using Entities.Models;
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

            var orderByParams = orderbyQueryString.Trim().Split(',');
            var propertyInfos = typeof(Candidate).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderByQueryBuilder = new StringBuilder();

            foreach(var param in orderByParams)
            {
                if(string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;
                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                orderByQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }

            var orderQuery = orderByQueryBuilder.ToString().TrimEnd(',', ' ');

            if(string.IsNullOrWhiteSpace(orderQuery))
                return candidates.OrderBy(c => c.Name);

            return candidates.OrderBy(orderQuery);
        }
    }
}
