
using SenseWebApi1.Features.EventFeature;

namespace SenseWebApi1.Services;

public class HttpService:IHttpService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<HttpService> _logger;
    // ReSharper disable once NotAccessedField.Local
    private IHttpContextAccessor _contextAccessor;
    public HttpService(IHttpContextAccessor contextAccessor,ILogger<HttpService> logger)
    {
        _logger = logger;
        _httpClient = new HttpClient();
        
#pragma warning disable CS8602
        // ReSharper disable once RedundantSuppressNullableWarningExpression
        var jwt= contextAccessor.HttpContext.Request.Headers["Authorization"]!;
#pragma warning restore CS8602
        _httpClient.DefaultRequestHeaders.Add("Authorization","" +jwt);
        _contextAccessor = contextAccessor;
    }

    public async Task<string> GetImages(string tocken)
    {
        var headerstring = "";
        foreach (var item in _httpClient.DefaultRequestHeaders)
        {
            headerstring += $"{item.Key}={item.Value}\n";
        }
        _logger.LogInformation("Request GET\n {0}   ", headerstring);
        var response = await _httpClient.GetAsync(new Uri("http://imageapi:80/images"));
        var result =await response.Content.ReadAsStringAsync();
        return result;
       
    }

    public async Task<string> GetSpaces(string tocken)
    {
        
        var headerstring = "";
        foreach (var item in _httpClient.DefaultRequestHeaders)
        {
            headerstring += $"{item.Key}={item.Value}\n";
        }
        _logger.LogInformation("Request GET\n {0}   ", headerstring);
        var response = await _httpClient.GetAsync(new Uri("http://spaceapi:80/spaces"));
        var result =await response.Content.ReadAsStringAsync();
        return result;
    }

    public async Task<HttpResponseMessage> CreateTransaction(Guid ownerId,CancellationToken cancellationToken)
    {
        var headerstring = "";
        foreach (var item in _httpClient.DefaultRequestHeaders)
        {
            headerstring += $"{item.Key}={item.Value}\n";
        }
        _logger.LogInformation("Request POST\n {0}   ", headerstring);
        Event eventObj = new Event();
        var response = await _httpClient.PostAsync($"http://paymentapi:80/payment/{ownerId}",JsonContent.Create(eventObj),cancellationToken);
        return response;
        
    }
    public async Task<HttpResponseMessage> ConfirmTransaction(Guid id,CancellationToken cancellationToken)
    {
        var headerstring = "";
        foreach (var item in _httpClient.DefaultRequestHeaders)
        {
            headerstring += $"{item.Key}={item.Value}\n";
        }
        _logger.LogInformation("Request PUTCH\n {0}   ", headerstring);
        Event eventObj = new Event();
        var response = await _httpClient.PatchAsync($"http://paymentapi:80/payment/confirm/{id}",JsonContent.Create(eventObj),cancellationToken);
        return response;
        
    }
    
    public async Task<HttpResponseMessage> CancelTransaction(Guid id,CancellationToken cancellationToken)
    {
        var headerstring = "";
        foreach (var item in _httpClient.DefaultRequestHeaders)
        {
            headerstring += $"{item.Key}={item.Value}\n";
        }
        _logger.LogInformation("Request PUTCH\n {0}   ", headerstring);
        Event eventObj = new Event();
        var response = await _httpClient.PatchAsync($"http://paymentapi:80/payment/cancel/{id}",JsonContent.Create(eventObj),cancellationToken);
        return response;
        
    }
}