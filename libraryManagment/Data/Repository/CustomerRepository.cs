using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Repository
{
    public class CustomerRepository : Repository<Customer> ,  ICustomerRepository
    {
        public CustomerRepository(LibraryDbContext context) : base (context)
        {

        }
    }
}
