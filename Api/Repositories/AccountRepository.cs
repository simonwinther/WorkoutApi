using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkoutApi.Data;
using WorkoutApi.Models;

namespace WorkoutApi.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDataContext _context;
        public AccountRepository(IDataContext context)
        {
            _context = context;
        }
        public async Task Add(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _context.Accounts.FindAsync(id);
            if (item is not null)
                throw new NullReferenceException();
            _context.Accounts.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Account> GetAccount(string username)
        {
            return await _context.Accounts.FindAsync(username);
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task Update(Account account)
        {
            var item = await _context.Accounts.FindAsync(account.Id);
            if (item is not null)
                throw new NullReferenceException();
            item.UserName = account.UserName;
            item.Password = account.Password;
            await _context.SaveChangesAsync(); await _context.SaveChangesAsync();
        }
    }
}