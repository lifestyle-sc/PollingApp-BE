namespace Shared.RequestFeatures
{
    public class PollParameters : RequestParameters
    {
        public PollParameters() => OrderBy = "name";
        public string? SearchTerm { get; set; }
    }
}
