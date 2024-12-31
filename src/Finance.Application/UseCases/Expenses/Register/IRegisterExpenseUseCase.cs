using Finance.Communication.Requests;
using Finance.Communication.Responses;

namespace Finance.Application.UseCases.Expenses.Register;
public interface IRegisterExpenseUseCase
{
  Task<ResponseRegisterExpenseJson> Execute(RequestExpenseJson request);
}
