using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IWriteRepository<T> : IQuery<T> where T : Entity
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
