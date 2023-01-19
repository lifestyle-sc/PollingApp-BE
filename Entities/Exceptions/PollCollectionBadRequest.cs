namespace Entities.Exceptions
{
    public sealed class PollCollectionBadRequest : BadRequestException
    {
        public PollCollectionBadRequest() : base("Poll collection is null")
        {

        }
    }
}
