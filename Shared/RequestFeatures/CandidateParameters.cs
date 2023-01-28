namespace Shared.RequestFeatures
{
    public class CandidateParameters : RequestParameters
    {
        public CandidateParameters() => OrderBy = "name";
        public string? SearchTerm { get; set; }
    }
}
