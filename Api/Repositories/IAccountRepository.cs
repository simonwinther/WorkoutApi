using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutApi.Models;

namespace WorkoutApi.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAccount(string username);
        Task<IEnumerable<Account>> GetAll();
        Task Add(Account account);
        Task Delete(int id);
        Task Update(Account account);
    }
}