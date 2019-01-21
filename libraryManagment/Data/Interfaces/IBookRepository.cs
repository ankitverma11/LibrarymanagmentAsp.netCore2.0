using LibraryManagment.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetAllWithAuthor();

        IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate);

        IEnumerable<Book> FindWithAuthorAndBorrowner(Func<Book, bool> predicate);
    }
}
