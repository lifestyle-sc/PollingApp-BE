namespace Contracts
{
    public interface IRepositoryManager
    {
        ICandidateRepository Candidate { get; }

        IPollRepository Poll { get; }

        void Save();
    }
}
