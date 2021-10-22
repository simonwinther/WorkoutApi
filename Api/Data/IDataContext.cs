using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkoutApi.Models;

namespace WorkoutApi.Data
{
    public interface IDataContext
    {
        DbSet<Exercise> Exercises { get; init; }
        public DbSet<Account> Accounts { get; init; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}