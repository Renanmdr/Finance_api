using Finance.Domain.Entities;

namespace Finance.Domain.Repositories.Expenses;
public interface IExpensesUpdateOnlyRepository
{
   void Update(Expense expense);
    Task<Expense?> GetById(long id);
}
