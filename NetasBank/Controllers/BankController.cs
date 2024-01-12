using Microsoft.AspNetCore.Mvc;

namespace NetasBank.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BankController : ControllerBase
{
    public BankController()
    {
    }

    [HttpGet("syncsale")]
    public IEnumerable<string> GetOnSaleProducts()
    {
        return null;
    }
}
