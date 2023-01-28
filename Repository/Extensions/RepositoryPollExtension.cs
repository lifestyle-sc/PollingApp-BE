using Entities.Models;

namespace Repository.Extensions
{
    public static class RepositoryPollExtension
    {
        public static IQueryable<Poll> Search(this IQueryable<Poll> polls, string searchTerm)
        {
            if (String.IsNullOrWhiteSpace(searchTerm))
                return polls;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return polls.Where(x => x.Name.ToLower().Contains(searchTerm));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
