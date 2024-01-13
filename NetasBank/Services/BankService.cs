using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetasBank.Context;
using NetasBank.Requests;
using NetasBank.Responses;

namespace NetasBank.Services;
public class BankService : IBankService
{
    private readonly NetasBankContext _context;
    private readonly IMapper _mapper;
    public BankService(NetasBankContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Cancel(CancelTransactionRequestRecord request)
    {
        OperationContext context = new OperationContext(_context);
        return await context.Cancel(request.BankId, request);
    }

    public async Task<bool> Refund(RefundTransactionRequestRecord request)
    {
        OperationContext context = new OperationContext(_context);
        return await context.Refund(request.BankId, request);
    }

    public async Task<bool> Pay(CreateTransactionDetailsRequestRecord request)
    {
        OperationContext context = new OperationContext(_context);
        return await context.Pay(request.BankId, request);
    }

    public async Task<ICollection<ReportingResponse>> Report(ReportingRequest request)
    {
        var query = _context.Transactions.AsQueryable();
        if (request.BankId != null)
        {
            query = query.Where(x => x.BankId == request.BankId).Include(x => x.TransactionDetails);
        }
        if (request.TransactionDateBegin != null)
        {
            query = query.Where(x => x.TransactionDate >= request.TransactionDateBegin).Include(x => x.TransactionDetails);
        }
        if (request.TransactionDateEnd != null)
        {
            query = query.Where(x => x.TransactionDate <= request.TransactionDateEnd).Include(x => x.TransactionDetails);
        }
        if (!string.IsNullOrEmpty(request.OrderReference))
        {
            query = query.Where(x => x.OrderReference == request.OrderReference).Include(x => x.TransactionDetails);
        }
        if (request.TransactionStatus != null)
        {
            query = query.Where(x => x.TxStatus == request.TransactionStatus).Include(x => x.TransactionDetails);
        }

        return _mapper.Map<ICollection<ReportingResponse>>(await query.ToListAsync());

    }
}
