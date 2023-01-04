namespace Service.Contracts
{
    public interface IServiceManager
    {
        IPollService PollService { get; }

        ICandidateService CandidateService { get; }
    }
}
