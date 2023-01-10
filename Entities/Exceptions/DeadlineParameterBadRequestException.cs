namespace Entities.Exceptions
{
    public sealed class DeadlineParameterBadRequestException : BadRequestException
    {
        public DeadlineParameterBadRequestException(DateTime deadline) : base($"The poll deadline: {deadline} is in the past.")
        {

        }
    }
}
