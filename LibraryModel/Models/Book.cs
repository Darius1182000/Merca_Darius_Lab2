using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryModel.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public int? AuthorID { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
       [ Display (Name = "Author")]

        public Author? Author { get; set; }
        public ICollection<Order>? Orders { get; set; }

        public ICollection<PublishedBook>? PublishedBooks { get; set; }
    }
}
