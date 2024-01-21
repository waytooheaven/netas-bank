using NetasBank.Enums;
using NetasBank.Models;
using NetasBank.Requests;

namespace NetasBank.Common
{
    public static class ObjectCreator
    {
        public static TransactionDetailsModel CreateTransactionDetailsModel(this TransactionDetailsModel model, BaseModel transaction, RequestRecord request, TransactionType type)
        {
            model.TransactionId = transaction.Id;
            model.TxType = type;
            model.Amount = request.Amount;
            model.TxStatus = Enums.TransactionStatus.Success;
            return model;
        }
    }
}
