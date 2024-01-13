using AutoMapper;
using NetasBank.Models;
using NetasBank.Responses;

namespace NetasBank.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TransactionsModel, ReportingResponse>();
        CreateMap<TransactionDetailsModel, ReportingTransactionDetail>();
    }
}