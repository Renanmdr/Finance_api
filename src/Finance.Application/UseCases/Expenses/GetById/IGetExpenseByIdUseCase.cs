using Finance.Communication.Responses;

namespace Finance.Application.UseCases.Expenses.GetById;
public interface IGetExpenseByIdUseCase
{
    Task<ResponseExpenseJson> Execute(long id);
}
