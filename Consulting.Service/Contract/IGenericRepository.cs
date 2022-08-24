using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consulting.Service.Contract
{
    public interface IGenericRepository<T> where T : class
    {

        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
        void Save();

        Task<int> SaveChangesAsync();
    }
}
