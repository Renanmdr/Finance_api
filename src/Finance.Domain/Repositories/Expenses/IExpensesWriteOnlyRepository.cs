using Finance.Domain.Entities;

namespace Finance.Domain.Repositories.Expenses;
public interface IExpensesWriteOnlyRepository
{
    Task Add(Expense expense);
    
    /// <summary>
    /// this function returns TRUE if the deletion was successful
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}
