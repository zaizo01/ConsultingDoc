using Consulting.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consulting.Service.Contract
{
    public interface IGenericRepository<T> where T : class
    {

        Task<Response<IEnumerable<T>>> GetAll();
        Task<Response<T>> GetById(Guid id);
        Task<Response<T>> Create(T entity);
        Task<Response<T>> Update(T entity);
        Task<Response<T>> Delete(Guid id);
        void Save();

        Task<int> SaveChangesAsync();
    }
}
