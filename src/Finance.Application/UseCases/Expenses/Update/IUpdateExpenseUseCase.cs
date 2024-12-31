using Finance.Communication.Requests;

namespace Finance.Application.UseCases.Expenses.Update;
public interface IUpdateExpenseUseCase
{
    Task Execute(long id, RequestExpenseJson request);
}
