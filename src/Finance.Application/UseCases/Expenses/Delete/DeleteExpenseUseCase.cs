using Finance.Communication.Responses;
using Finance.Domain.Repositories;
using Finance.Domain.Repositories.Expenses;
using Finance.Exception;
using Finance.Exception.ExceptionsBase;

namespace Finance.Application.UseCases.Expenses.Delete;
public class DeleteExpenseUseCase : IDeleteExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteExpenseUseCase(IExpensesWriteOnlyRepository repository, IUnitOfWork unitOfWork )
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(long id)
    {
        var result  = await _repository.Delete( id );

        if (result is false) {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

       await _unitOfWork.Commit();
    }
}
