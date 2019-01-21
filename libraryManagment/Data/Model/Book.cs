using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        //RelationShip with Author
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }
        //RelationShip with Author
        public virtual Customer Borrowner { get; set; }
        public int BorrownerId { get; set; }

    }
}
