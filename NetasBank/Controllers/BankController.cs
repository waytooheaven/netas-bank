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

    [ServiceFilter(typeof(IsBankBelongsToTransactionActionFilter))]
    [HttpPost("pay")]
    public async Task<ActionResult> Pay([FromBody] CreateTransactionDetailsRequestRecord request)
    {
        await _bankService.Pay(request);
        return Ok();
    }

    [ServiceFilter(typeof(IsBankBelongsToTransactionActionFilter))]
    [HttpPost("refund")]
    public async Task<ActionResult> Refund([FromBody] RefundTransactionRequestRecord request)
    {
        await _bankService.Refund(request);
        return Ok();
    }

    [ServiceFilter(typeof(IsBankBelongsToTransactionActionFilter))]
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
