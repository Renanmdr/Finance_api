using Finance.Communication.Responses;

namespace Finance.Application.UseCases.Expenses.GetAll;
public interface IGetAllExpenseUseCase
{
    Task<ResponseExpensesJson> Execute();
}
