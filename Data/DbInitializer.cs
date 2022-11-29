//using LibraryModel.Controllers;
using LibraryModel.Models;
using LibraryModel.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static NuGet.Packaging.PackagingConstants;
using static System.Reflection.Metadata.BlobBuilder;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using Publisher = LibraryModel.Models.Publisher;
using Merca_Darius_Lab2.Controllers;
//using Merca_Darius_Lab2.Models;
//using Publisher = Merca_Darius_Lab2.Models.Publisher;

//namespace LibraryModel.Data
namespace Merca_Darius_Lab2.Data
{
    public static class DbInitializer
    {
       
 public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new
           LibraryContext(serviceProvider.GetRequiredService
            <DbContextOptions<LibraryContext>>());


            if (context.Books.Any())
            {
                return; // BD a fost creata anterior
            }
           var orders = new Order[]
        {
            new Order{CustomerID=1,BookID=9,OrderDate=DateTime.Parse("2021-02-25")},
            new Order{CustomerID=2,BookID=12,OrderDate=DateTime.Parse("2021-09-28")},
            new Order{CustomerID=3,BookID=15,OrderDate=DateTime.Parse("2021-10-28")},
            new Order{CustomerID=4,BookID=16,OrderDate=DateTime.Parse("2021-09-28")},
            new Order{CustomerID=5,BookID=17,OrderDate=DateTime.Parse("2021-09-28")},
            new Order{CustomerID=6,BookID=21,OrderDate=DateTime.Parse("2021-10-28")},
          
         /* new Order
          {
              CustomerID=context.Customers.Single(g=>g.Name=="Viorel Marel").CustomerID,
              BookID= context.Books.Single(g=>g.Title=="Maytrei").ID,
              OrderDate=DateTime.Parse("2021-10-28")

          }*/
                   };
            foreach (Order e in orders)
           {
                context.Orders.Add(e);
            }
            context.SaveChanges();
            var publishers = new Publisher[]
            {

          new Publisher{PublisherName="Humanitas",Adress="Str. Aviatorilor, nr. 40, Bucuresti"},
          new Publisher{PublisherName="Nemira",Adress="Str. Plopilor, nr. 35, Ploiesti"},
          new Publisher{PublisherName="Paralela 45",Adress="Str. Cascadelor, nr. 22, Cluj-Napoca"},
            };
            foreach (Publisher p in publishers)
            {
                context.Publishers.Add(p);
            }
            context.SaveChanges();
            var publishedbooks = new PublishedBook[]
            {
     new PublishedBook {
        BookID = context.Books.Single(c => c.Title == "Maytrei" ).ID,
        PublisherID = publishers.Single(i => i.PublisherName =="Humanitas").ID
 },
     new PublishedBook {
        BookID = context.Books.Single(c => c.Title == "Enigma Otiliei" ).ID,
        PublisherID = publishers.Single(i => i.PublisherName =="Humanitas").ID
 },
     new PublishedBook {
         BookID = context.Books.Single(c => c.Title == "Baltagul" ).ID,
         PublisherID = publishers.Single(i => i.PublisherName =="Nemira").ID
 },
     new PublishedBook {
         BookID = context.Books.Single(c => c.Title == "Fata de hartie" ).ID,
         PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
 },
     new PublishedBook {
         BookID = context.Books.Single(c => c.Title == "Panza de paianjen" ).ID,
         PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
 },
     new PublishedBook {
         BookID = context.Books.Single(c => c.Title == "De veghe in lanul de secara" ).ID,
         PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
 },
 };
            foreach (PublishedBook pb in publishedbooks)
            {
                context.PublishedBooks.Add(pb);
            }
            context.SaveChanges();
        }
    }

}