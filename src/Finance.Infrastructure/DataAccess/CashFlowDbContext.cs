using Finance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infrastructure.DataAccess;
public class CashFlowDbContext : DbContext
{
    public CashFlowDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Expense> Expenses { get; set; }

    
}
