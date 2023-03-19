namespace SenseWebApi1.Features.EventFeature
{
    public class Image
    {
        public Guid ImageId { get; set; }
        // ReSharper disable once InconsistentNaming
#pragma warning disable CS8618
        public string src { get; set; }
#pragma warning restore CS8618
    }
}
