using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Zip.Accounts.Core.Common;
using Zip.Accounts.Core.Repositories;

namespace Zip.Accounts.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly AccountContext _context;
        public BaseRepository(AccountContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T obj)
        {
            var entityEntry = _context.Set<T>().Add(obj);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync(int id)
        {
            return _context.Set<T>().Where(e => e.Id == id).FirstOrDefault();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).FirstOrDefault();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return (IList<T>)(await _context.Set<T>().ToListAsync());
        }

        public async Task<bool> UpdateAsync(T obj)
        {
            _context.Set<T>().Update(obj);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
