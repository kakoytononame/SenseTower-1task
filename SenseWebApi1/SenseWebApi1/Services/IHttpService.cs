namespace SenseWebApi1.Services;

public interface IHttpService
{
    Task<string> GetImages(string tocken);

    Task<string> GetSpaces(string tocken);

    Task<HttpResponseMessage> CreateTransaction(Guid ownerId, CancellationToken cancellationToken);
    
    Task<HttpResponseMessage> ConfirmTransaction(Guid ownerId, CancellationToken cancellationToken);
    
    Task<HttpResponseMessage> CancelTransaction(Guid ownerId, CancellationToken cancellationToken);
}