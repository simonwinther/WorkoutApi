using Microsoft.EntityFrameworkCore;
using WorkoutApi.Models;
using System.Threading.Tasks;
using System.Threading;

namespace WorkoutApi.Data
{
    public interface IAccountContext
    {
        DbSet<Account> Accounts { get; init; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}