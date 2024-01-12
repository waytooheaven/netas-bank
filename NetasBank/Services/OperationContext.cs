using NetasBank.Banks;
using NetasBank.Requests;

namespace NetasBank.Services;
public sealed class OperationContext
{
    private readonly Dictionary<int, BaseBank> _operationStrategy = new Dictionary<int, BaseBank>();

    public OperationContext()
    {
        _operationStrategy.Add(1, new Garanti());
        _operationStrategy.Add(2, new YapiKredi());
        _operationStrategy.Add(3, new Akbank());
    }

    public async Task<bool> Pay(int searchType, CreateTransactionDetailsRequestRecord request)
    {
        return await _operationStrategy[searchType].Pay(request);
    }
    public async Task<bool> Cancel(int searchType, CancelTransactionRequestRecord request)
    {
        return await _operationStrategy[searchType].Cancel(request);
    }
    public async Task<bool> Refund(int searchType, RefundTransactionRequestRecord request)
    {
        return await _operationStrategy[searchType].Refund(request);
    }
}
