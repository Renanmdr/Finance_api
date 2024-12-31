using Finance.Communication.Responses;

namespace Finance.Application.UseCases.Expenses.Delete;
public interface IDeleteExpenseUseCase
{
    Task Execute(long id);
}
