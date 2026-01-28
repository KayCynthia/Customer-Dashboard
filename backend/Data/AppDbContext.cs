using Microsoft.EntityFrameworkCore;
using FinanceBackend.Models; // This allows us to use Transaction and SavingsGoal

namespace FinanceBackend.Data;

public class AppDbContext : DbContext
{
    // The constructor: This passes your connection settings to the base 'DbContext'
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    { }

    // These lines create the actual tables in the database
    public DbSet<Transaction> Transaction { get; set; }
    public DbSet<Savingsgoal> Savingsgoal { get; set; }
}