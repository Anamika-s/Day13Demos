using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day13Demos.Models;

namespace Day13Demos
{
    class Program2
    {
        static void Main()
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            {

                var author = new Author
                {
                    FirstName = "William",
                    LastName = "Shakespeare",
                    Books = new List<Book>
                    {
                        new Book { Title = "Hamlet"},
                        new Book { Title = "Othello" },
                        new Book { Title = "MacBeth" }
                    }
                };
                db.Authors.Add(author);
                db.SaveChanges();
                //db.Dispose();
            }

            using (var context = new EmployeeDbContext())
            {
                foreach (var temp in context.Books)
                {
                    Console.WriteLine(temp.Title);
                }
            }

        }
    }
}
