using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Context;
using SC.Internship.Common.ScResult;

namespace PaymentAPI.Features.PaymentFeature;

[Authorize]
public class PaymentController:ControllerBase
{
    private readonly IPaymentTransaction _paymentTransaction;
    public PaymentController(IPaymentTransaction paymentTransaction)
    {
        _paymentTransaction = paymentTransaction;
    }
    
    
    [HttpPost("payment/{ownerId}")]
    public async Task<IActionResult> CreateTransaction([FromRoute] Guid ownerId)
    {
        var result =await _paymentTransaction.CreateTransaction(ownerId);
        return Ok(new ScResult<Guid>()
        {
            Result = result
        });
    }
    
    [HttpPatch("payment/confirm/{id}")]
    public async Task<IActionResult> ConfirmTransaction([FromRoute] Guid id)
    {
        var result =await _paymentTransaction.ConfirmTransaction(id);
        return Ok(new ScResult<Guid>()
        {
            Result = result
        });
    }
    
    [HttpPatch("payment/cancel/{id}")]
    public async Task<IActionResult> CancelTransaction([FromRoute] Guid id)
    {
        var result =await _paymentTransaction.CancelTransaction(id);
        return Ok(new ScResult<Guid>()
        {
            Result = result
        });
    }
}