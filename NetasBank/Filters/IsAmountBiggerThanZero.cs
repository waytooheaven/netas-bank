using Microsoft.AspNetCore.Mvc.Filters;
using NetasBank.Context;
using NetasBank.Exceptions;
using NetasBank.Requests;

namespace NetasBank.Filters
{
    public class IsAmountBiggerThanZero : ActionFilterAttribute
    {
        private NetasBankContext _context;

        public IsAmountBiggerThanZero(NetasBankContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var payload = context.ActionArguments["request"] as RequestRecord;
            if (payload != null)
            {
                if(payload.Amount <= 0)
                {
                    throw new ApiException("The amount must be bigger than 0");
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
