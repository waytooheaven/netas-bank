using Microsoft.EntityFrameworkCore;
using NetasBank.Requests;

namespace NetasBank.Context
{
    public class TheMasterContext : NetasBankContext
    {
        public TheMasterContext(DbContextOptions<TheMasterContext> options) : base(options)
        {
        }

        public void WriteToFile(RequestRecord request)
        {
            using (StreamWriter writer = System.IO.File.AppendText("netas-bank.txt"))
            {
                string StringFormat = String.Format("{0} {1} {2}", request.TransactionId, request.Amount, request.BankId);
                writer.WriteLine(StringFormat);
            }
        }
    }
}
