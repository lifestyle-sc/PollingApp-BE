namespace Entities.Exceptions
{
    public sealed class IdsParameterBadRequest : BadRequestException
    {
        public IdsParameterBadRequest() : base("The Ids provided by the client is null")
        {

        }
    }
}
