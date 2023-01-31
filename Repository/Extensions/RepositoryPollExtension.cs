using Entities.Models;
using Repository.Extensions.Utilities;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class RepositoryPollExtension
    {
        public static IQueryable<Poll> Search(this IQueryable<Poll> polls, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return polls;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return polls.Where(x => x.Name.ToLower().Contains(searchTerm));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public static IQueryable<Poll> Sort(this IQueryable<Poll> polls, string orderByQueryString)
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString))
                return polls.OrderBy(p => p.Name);

            var orderByQuery = OrderQueryBuilder.CreateOrderQuery<Poll>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderByQuery))
                return polls.OrderBy(p => p.Name);

            return polls.OrderBy(orderByQuery);
        }
    }
}
