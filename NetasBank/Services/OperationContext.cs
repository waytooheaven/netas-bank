using NetasBank.Banks;
using NetasBank.Context;
using NetasBank.Enums;
using NetasBank.Requests;

namespace NetasBank.Services;
public sealed class OperationContext
{
    private readonly Dictionary<BankEnum, BaseBank> _operationStrategy = new Dictionary<BankEnum, BaseBank>();
    private readonly NetasBankContext _context;

    public OperationContext(NetasBankContext context)
    {
        _context = context;
        _operationStrategy.Add(BankEnum.Garanti, new Garanti(_context));
        _operationStrategy.Add(BankEnum.YapiKredi, new YapiKredi(_context));
        _operationStrategy.Add(BankEnum.Akbank, new Akbank(_context));
    }

    public async Task<bool> Pay(BankEnum searchType, CreateTransactionDetailsRequestRecord request)
    {
        return await _operationStrategy[searchType].Pay(request);
    }
    public async Task<bool> Cancel(BankEnum searchType, CancelTransactionRequestRecord request)
    {
        return await _operationStrategy[searchType].Cancel(request);
    }
    public async Task<bool> Refund(BankEnum searchType, RefundTransactionRequestRecord request)
    {
        return await _operationStrategy[searchType].Refund(request);
    }
}
