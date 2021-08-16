using Microsoft.EntityFrameworkCore;
using WorkoutApi.Models;

namespace WorkoutApi.Data
{
    public class AccountContext : DbContext, IAccountContext
    {
        public AccountContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; init; }
    }
}