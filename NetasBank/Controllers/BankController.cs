using Microsoft.AspNetCore.Mvc;
using NetasBank.Filters;
using NetasBank.Requests;
using NetasBank.Services;

namespace NetasBank.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BankController : ControllerBase
{
    private readonly IBankService _bankService;
    public BankController(IBankService bankService)
    {
        _bankService = bankService;
    }

    /// <summary>
    /// Makes a payment
    /// </summary>
    /// <returns>Returns success</returns>
    // POST: api/pay
    [ServiceFilter(typeof(IsBankBelongsToTransactionActionFilter))]
    [ServiceFilter(typeof(IsAmountBiggerThanZero))]
    [HttpPost("pay")]
    public async Task<ActionResult> Pay([FromBody] CreateTransactionDetailsRequestRecord request)
    {
        await _bankService.Pay(request);
        return Ok();
    }

    /// <summary>
    /// Makes a refund
    /// </summary>
    /// <returns>Returns success</returns>
    // POST: api/refund
    [ServiceFilter(typeof(IsBankBelongsToTransactionActionFilter))]
    [ServiceFilter(typeof(IsAmountBiggerThanZero))]
    [HttpPost("refund")]
    public async Task<ActionResult> Refund([FromBody] RefundTransactionRequestRecord request)
    {
        await _bankService.Refund(request);
        return Ok();
    }

    /// <summary>
    /// Cancels a transaction
    /// </summary>
    /// <returns>Returns success</returns>
    // POST: api/cancel
    [ServiceFilter(typeof(IsBankBelongsToTransactionActionFilter))]
    [ServiceFilter(typeof(IsAmountBiggerThanZero))]
    [HttpPost("cancel")]
    public async Task<ActionResult> Cancel([FromBody] CancelTransactionRequestRecord request)
    {
        await _bankService.Cancel(request);
        return Ok();
    }

    [HttpPost("report")]
    public async Task<ActionResult> Report([FromBody] ReportingRequest request)
    {
        var result = await _bankService.Report(request);
        return Ok(result);
    }
}
