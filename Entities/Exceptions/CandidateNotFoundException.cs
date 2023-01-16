namespace Entities.Exceptions
{
    public sealed class CandidateNotFoundException : NotFoundException
    {
        public CandidateNotFoundException(Guid id) : base($"The candidate with Id: {id} doesn't exist in the database.")
        {

        }
    }
}
