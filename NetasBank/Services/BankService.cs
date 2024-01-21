using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetasBank.Context;
using NetasBank.Requests;
using NetasBank.Responses;

namespace NetasBank.Services;
public class BankService : IBankService
{
    private readonly TheMasterContext _context;
    private readonly IMapper _mapper;
    public BankService(TheMasterContext context, IMapper mapper)
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
        var query = _context.Transactions.Include(x => x.TransactionDetails).AsQueryable();
        if (request.BankId != null)
        {
            query = query.Where(x => x.BankId == request.BankId);
        }
        if (request.TransactionDateBegin != null)
        {
            query = query.Where(x => x.TransactionDate >= request.TransactionDateBegin);
        }
        if (request.TransactionDateEnd != null)
        {
            query = query.Where(x => x.TransactionDate <= request.TransactionDateEnd);
        }
        if (!string.IsNullOrEmpty(request.OrderReference))
        {
            query = query.Where(x => x.OrderReference == request.OrderReference);
        }
        if (request.TransactionStatus != null)
        {
            query = query.Where(x => x.TxStatus == request.TransactionStatus);
        }

        return _mapper.Map<ICollection<ReportingResponse>>(await query.AsNoTracking().ToListAsync());

    }
}
