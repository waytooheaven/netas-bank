using Microsoft.AspNetCore.Mvc;
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

    [HttpPost("pay")]
    public async Task<ActionResult> Pay([FromBody] CreateTransactionDetailsRequestRecord request)
    {
        await _bankService.Pay(request);
        return Ok();
    }

    [HttpPost("refund")]
    public async Task<ActionResult> Refund([FromBody] RefundTransactionRequestRecord request)
    {
        await _bankService.Refund(request);
        return Ok();
    }

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
