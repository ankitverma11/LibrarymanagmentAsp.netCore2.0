using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {
        }

        // built-in generic delegate types Func and Action, so that you don't need to define custom delegates as above.
        //Func is a generic delegate included in the System namespace.It has zero or more input parameters and one out parameter.The last parameter is considered as an out parameter.
        public IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate)
        {
            return _context.Books
                    .Include(x => x.Author)
                     .Where(predicate);
        }

        public IEnumerable<Book> FindWithAuthorAndBorrowner(Func<Book, bool> predicate)
        {
            return _context.Books
                .Include(x => x.Author)
                .Include(x => x.Borrowner)
                .Where(predicate);
        }

        public IEnumerable<Book> GetAllWithAuthor()
        {
            return _context.Books
                   .Include(a => a.Author);
        }
    }
}
