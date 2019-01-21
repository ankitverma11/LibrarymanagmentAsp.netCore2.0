using LibraryManagment.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data
{
    public static class DbInitialize
    {
        public static void Seed(IApplicationBuilder app) // IApplicationBuilder beacuse we need to access our dbcontext and using DI
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();
                // Add Customer
                var Ankit = new Customer { Name = "Ankit Verma" };
                var Amit = new Customer { Name = "Amit Sharma" };
                var Virat = new Customer { Name = "Virat Kohli" };

                context.Customers.Add(Ankit);
                context.Customers.Add(Amit);
                context.Customers.Add(Virat);

                //Add Author
                var NewDemacro = new Author
                {
                    Name = "MJ Demacro",
                    Books = new List<Book>()
                    {
                        new Book { Title ="The millionaire Fastlane"},
                        new Book {Title = "Unscripted"}
                    }
                };

                var cardone = new Author
                {
                    Name = "Grant Cardone",
                    Books = new List<Book>()
                    {
                        new Book { Title ="The 10X Rules"},
                        new Book {Title = "Sell to Servive"},
                        new Book {Title = "The Nut"}
                    }
                };

                context.Authors.Add(NewDemacro);
                context.Authors.Add(cardone);

                context.SaveChanges();
            }
        }
    }
}
