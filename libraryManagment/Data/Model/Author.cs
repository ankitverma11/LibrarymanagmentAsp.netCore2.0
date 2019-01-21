using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        //relationship with book Class
        public virtual ICollection<Book> Books { get; set; }
    }
}
