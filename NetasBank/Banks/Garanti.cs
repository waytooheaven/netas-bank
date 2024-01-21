using NetasBank.Common;
using NetasBank.Context;
using NetasBank.Enums;
using NetasBank.Requests;

namespace NetasBank.Banks;
public sealed class Garanti : BaseBank
{
    private readonly TheMasterContext _context;
    private readonly BankEnum MasterBank = BankEnum.Garanti;
    public Garanti(TheMasterContext context)
    {
        _context = context;
    }

    public async override Task<bool> Cancel(CancelTransactionRequestRecord request)
    {
        return await TheEye.Cancel(_context, request, MasterBank);
    }

    public async override Task<bool> Pay(CreateTransactionDetailsRequestRecord request)
    {
        return await TheEye.Pay(_context, request, MasterBank);
    }

    public async override Task<bool> Refund(RefundTransactionRequestRecord request)
    {
        return await TheEye.Refund(_context, request, MasterBank);
    }
}
