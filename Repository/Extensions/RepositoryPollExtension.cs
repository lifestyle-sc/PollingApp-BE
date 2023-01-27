using Entities.Models;

namespace Repository.Extensions
{
    public static class RepositoryPollExtension
    {
        public static IQueryable<Poll> Search(this IQueryable<Poll> polls, string searchTerm)
        {
            if(String.IsNullOrEmpty(searchTerm))
                return polls

            return polls.Where(x => x.Name.Contains(searchTerm));
        }
    }
}
