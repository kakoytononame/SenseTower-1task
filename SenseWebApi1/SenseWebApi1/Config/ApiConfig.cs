namespace SenseWebApi1.Config;




public class ApiConfig : IApiConfig
{
#pragma warning disable CS8618
    public string AccessToken { get; set; }

    public string BaseUrl { get; set; }
}
