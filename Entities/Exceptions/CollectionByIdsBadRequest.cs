namespace Entities.Exceptions
{
    public sealed class CollectionByIdsBadRequest : BadRequestException
    {
        public CollectionByIdsBadRequest() : base("Collection count mismatch comparing to ids")
        {

        }
    }
}
