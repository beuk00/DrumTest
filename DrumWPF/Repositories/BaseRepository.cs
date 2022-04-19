using DrumLib.Interfaces;
using DrumLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrumWPF.Repositories
{
    internal abstract class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
       
            //protected string baseUrl = "https://localhost:44369/api/";

            public abstract Task<T> Create(T entity);

            public abstract Task<T> Delete(T entity);

            public abstract Task<T> DeleteById(int id);

            public abstract IQueryable<T> GetAll();

            public abstract Task<T> GetById(int id);

            public abstract Task<IEnumerable<T>> ListAll();

            public abstract Task<T> Update(T entity);
        }
}
