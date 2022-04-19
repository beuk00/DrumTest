using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrumLib.Interfaces
{
    public interface IRepository<T>
    {
        // read
        Task<IEnumerable<T>> ListAll(); // in-memory
        IQueryable<T> GetAll(); // out-memory
        Task<T> GetById(int id);

        // create
        Task<T> Create(T entity);

        // delete
        Task<T> Delete(T entity);
        Task<T> DeleteById(int id);

        // update
        Task<T> Update(T entity);
    }
}
