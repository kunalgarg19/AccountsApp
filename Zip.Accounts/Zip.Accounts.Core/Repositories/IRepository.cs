using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Zip.Accounts.Core.Common;

namespace Zip.Accounts.Core.Repositories
{
    public interface IRepository<T> where T: IEntity
    {
        Task<T> AddAsync(T obj);

        Task<T> GetAsync(int id);

        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        Task<IList<T>> GetAllAsync();

        Task<bool> UpdateAsync(T obj);

        Task<T> DeleteAsync(int id);

        
    }
}
