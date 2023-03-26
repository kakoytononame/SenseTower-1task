using System.Net;
using MediatR;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using SC.Internship.Common.Exceptions;
using SC.Internship.Common.ScResult;
using SenseWebApi1.Context;
using SenseWebApi1.Services;

namespace SenseWebApi1.Features.TicketFeature.SellTicketForUser;

public class SellTicketForUserHandler:IRequestHandler<SellTicketForUserCommand,Ticket>
{
    private readonly ITicketContext _ticketContext;
    private readonly IHttpService _httpService;
    private RetryPolicy _retryPolicy=Policy.Handle<Exception>().Retry(2);

    public SellTicketForUserHandler(ITicketContext ticketContext,IHttpService httpService)
    {
        _ticketContext = ticketContext;
        _httpService = httpService;
        
    }
    public async Task<Ticket> Handle(SellTicketForUserCommand request, CancellationToken cancellationToken)
    {
        Ticket? result;
        Guid id;
        
        
        var response=await _retryPolicy.Execute(() =>_httpService.CreateTransaction(request.OwnerId, cancellationToken));
        
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            result= await _retryPolicy.Execute(()=>_ticketContext.SellTicketForUser(request.OwnerId, request.TicketId));
            var httpResult =await response.Content.ReadAsStringAsync(cancellationToken);
#pragma warning disable CS8602
            id = JsonConvert.DeserializeObject<ScResult<Guid>>(httpResult).Result;
#pragma warning restore CS8602
        }
        else
        {
            throw new ScException("Проблема с сервисом оплаты");
        }
        
#pragma warning disable CS8602
         
#pragma warning restore CS8602
        
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (result != null)
        {
            await _retryPolicy.Execute(()=>_httpService.ConfirmTransaction(id, cancellationToken));
        }
        else
        {
            await _retryPolicy.Execute(()=>_httpService.CancelTransaction(id, cancellationToken));
        }

        return result!;
        
    }
}