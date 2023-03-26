namespace SenseWebApi1.Config;

public interface IApiConfig
{
    string AccessToken { get; set; }
    string BaseUrl { get; set; }
}