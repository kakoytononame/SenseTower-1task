namespace SenseWebApi1.Features.EventFeature
{
    public class User
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public Guid UserId { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
#pragma warning disable CS8618
        public string UserName { get; set; }
#pragma warning restore CS8618
    }
}
