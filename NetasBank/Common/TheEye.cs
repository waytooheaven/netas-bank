using Microsoft.EntityFrameworkCore;
using NetasBank.Context;
using NetasBank.Enums;
using NetasBank.Exceptions;
using NetasBank.Extensions;
using NetasBank.Models;
using NetasBank.Requests;

namespace NetasBank.Common
{
    public static class TheEye
    {
        public static async Task<bool> Cancel(NetasBankContext _context, CancelTransactionRequestRecord request, BankEnum bankEnum)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == request.TransactionId && x.BankId == bankEnum);

            if (transaction == null)
            {
                throw new ApiException($"Transaction {request.TransactionId} does not exist");
            }

            if (transaction.NetAmount - request.Amount < 0 ||
           transaction.TotalAmount - request.Amount < 0)
            {
                throw new ApiException($"Too much decrease in the total amount");
            }

            var txDetail = (new TransactionDetailsModel()).CreateTransactionDetailsModel(transaction, request, TransactionType.Cancel);
            await _context.TransactionDetails.AddAsync(txDetail);

            transaction.NetAmount -= request.Amount;
            transaction.TotalAmount -= request.Amount;
            transaction.OrderReference = StringExtensions.RandomString(10);
            transaction.BankId = request.BankId;
            transaction.TransactionDate = DateTime.UtcNow;
            transaction.TxStatus = Enums.TransactionStatus.Success;
            _context.Transactions.Update(transaction);

            await _context.SaveChangesAsync();

            return true;
        }

        public static async Task<bool> Pay(NetasBankContext _context, CreateTransactionDetailsRequestRecord request, BankEnum bankEnum)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == request.TransactionId && x.BankId == bankEnum);
            if (transaction == null)
            {
                var tx = new TransactionsModel();
                tx.TotalAmount = request.Amount;
                tx.NetAmount = request.Amount;
                tx.OrderReference = StringExtensions.RandomString(10);
                tx.BankId = request.BankId;
                tx.TransactionDate = DateTime.UtcNow;
                tx.TxStatus = Enums.TransactionStatus.Success;
                await _context.Transactions.AddAsync(tx);

                var txDetail = (new TransactionDetailsModel()).CreateTransactionDetailsModel(tx, request, TransactionType.Sale);
                await _context.TransactionDetails.AddAsync(txDetail);

                await _context.SaveChangesAsync();
            }
            else
            {
                transaction.NetAmount += request.Amount;
                transaction.TotalAmount += request.Amount;
                transaction.OrderReference = StringExtensions.RandomString(10);
                transaction.BankId = request.BankId;
                transaction.TransactionDate = DateTime.UtcNow;
                transaction.TxStatus = Enums.TransactionStatus.Success;
                _context.Transactions.Update(transaction);

                var txDetail = new TransactionDetailsModel();
                txDetail.TransactionId = transaction.Id;
                txDetail.TxType = Enums.TransactionType.Sale;
                txDetail.Amount = request.Amount;
                txDetail.TxStatus = Enums.TransactionStatus.Success;
                await _context.TransactionDetails.AddAsync(txDetail);

                await _context.SaveChangesAsync();
            }

            return true;
        }

        public static async Task<bool> Refund(NetasBankContext _context, RefundTransactionRequestRecord request, BankEnum bankEnum)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == request.TransactionId && x.BankId == bankEnum);

            if (transaction == null)
            {
                throw new ApiException($"Transaction {request.TransactionId} does not exist");
            }

            if (transaction.NetAmount - request.Amount < 0 ||
           transaction.TotalAmount - request.Amount < 0)
            {
                throw new ApiException($"Too much decrease in the total amount");
            }

            var txDetail = (new TransactionDetailsModel()).CreateTransactionDetailsModel(transaction, request, TransactionType.Refund);
            await _context.TransactionDetails.AddAsync(txDetail);

            transaction.NetAmount -= request.Amount;
            transaction.TotalAmount -= request.Amount;
            transaction.OrderReference = StringExtensions.RandomString(10);
            transaction.BankId = request.BankId;
            transaction.TransactionDate = DateTime.UtcNow;
            transaction.TxStatus = Enums.TransactionStatus.Success;
            _context.Transactions.Update(transaction);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
