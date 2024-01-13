using NetasBank.Enums;

namespace NetasBank.Requests
{
    public record ReportingRequest
    {
        public BankEnum? BankId { get; set; }
        public TransactionStatus? TransactionStatus { get; set; }
        public string? OrderReference { get; set; }
        public DateTime? TransactionDateBegin { get; set; }
        public DateTime? TransactionDateEnd { get; set; }
    }
}
