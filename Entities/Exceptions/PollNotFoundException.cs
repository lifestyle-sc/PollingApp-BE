namespace Entities.Exceptions
{
    public sealed class PollNotFoundException : NotFoundException
    {
        public PollNotFoundException(Guid PollId) : base($"The poll with Id: {PollId} doesn't exist in the database.")
        {

        }
    }
}
