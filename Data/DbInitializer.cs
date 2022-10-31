using Merca_Darius_Lab2.Controllers;
using Merca_Darius_Lab2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Merca_Darius_Lab2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if (context.Books.Any())
                {
                    return; // BD a fost creata anterior
                }
                /*     context.Books.AddRange(
                     new Book{ Title = "Baltagul", Price =Decimal.Parse("22")},

                     new Book{ Title = "Enigma Otiliei", Price=Decimal.Parse("18")},

                     new Book{ Title = "Maytrei", Price=Decimal.Parse("27")}

                     );


                     context.Customers.AddRange(
                     new Customer{ Name = "Popescu Marcela",Adress = "Str. Plopilor, nr. 24",BirthDate = DateTime.Parse("1979-09-01") },
                     new Customer{ Name = "Mihailescu Cornel",Adress = "Str. Bucuresti, nr.45,ap. 2",BirthDate=DateTime.Parse("1969 - 07 - 08")} );
                  */


            /*       context.Authors.AddRange(
                   new Author {  FirstName = "Mihail", LastName = "Sadoveanu" },
                   new Author {  FirstName = "George", LastName = "Calinescu" }
                   ) ;

               context.SaveChanges(); */
            /*
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Baltagul1",
                        Price = decimal.Parse("22"),
                      //  AuthorID = context.Authors.Single(author => author.LastName == "Sadoveanu").ID
                      //  Authors = context.Authors.Single(author => author.ID == 1).FirstName
                        Author = context.Authors.Single(author => author.LastName == "Sadoveanu")



                    },


                     new Book
                     {
                         Title = "Enigma Otiliei",
                         Price = decimal.Parse("18"),
                         // AuthorID = context.Authors.Single(author => author.LastName == "Calinescu").ID
                         //Author = "GeorgeCalinescu"
                         Author = context.Authors.Single(author => author.LastName == "Calinescu")

                     }


                 ) ; */
                context.Customers.AddRange(
                new Customer { Name = "Popescu Marcela", Adress = "Str. Plopilor, nr. 24", BirthDate = DateTime.Parse("1979-09-01") },
                new Customer { Name = "Mihailescu Cornel", Adress = "Str. Bucuresti, nr.45,ap. 2", BirthDate = DateTime.Parse("1969 - 07 - 08") });
                context.SaveChanges();
            }
        }
    }
}

