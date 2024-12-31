 using AutoMapper;
using Finance.Communication.Requests;
using Finance.Communication.Responses;
using Finance.Domain.Entities;

namespace Finance.Application.AutoMapper;
public class AutoMapping : Profile
{

    public AutoMapping() {

        RequestToEntity();
        EntityResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestExpenseJson, Expense>();
    }

    private void EntityResponse()
    {
        CreateMap<Expense, ResponseRegisterExpenseJson>();
        CreateMap<Expense, ResponseShortExpenseJson>();
        CreateMap<Expense, ResponseExpenseJson>();
    }

}




