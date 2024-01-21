using Microsoft.AspNetCore.Mvc.Filters;
using NetasBank.Context;
using NetasBank.Exceptions;
using NetasBank.Requests;

namespace NetasBank.Filters
{
    public class IsBankBelongsToTransactionActionFilter : ActionFilterAttribute
    {
        private TheMasterContext _context;

        public IsBankBelongsToTransactionActionFilter(TheMasterContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var payload = context.ActionArguments["request"] as RequestRecord;
            if (payload != null)
            {
                var transaction = _context.Transactions.FirstOrDefault(x => x.Id == payload.TransactionId);
                if (transaction != null)
                {
                    if (transaction.BankId != payload.BankId)
                    {
                        throw new ApiException("BankID might be wrong");
                    }
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
