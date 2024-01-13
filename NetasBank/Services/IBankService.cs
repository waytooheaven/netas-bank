using NetasBank.Requests;
using NetasBank.Responses;

namespace NetasBank.Services;
public interface IBankService
{
    Task<bool> Pay(CreateTransactionDetailsRequestRecord request);
    Task<bool> Cancel(CancelTransactionRequestRecord request);
    Task<bool> Refund(RefundTransactionRequestRecord request);
    Task<ICollection<ReportingResponse>> Report(ReportingRequest request);
}
