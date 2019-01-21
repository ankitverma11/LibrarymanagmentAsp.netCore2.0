using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Interfaces
{
    // Create A genric repository
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();   // to get All element with in the table

        IEnumerable<T> Find(Func<T, bool> predicate); // Filter and find object base Property

        T GetById(int id); // Search by ID

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        int Count(Func<T, bool> predicate);
    }
}
