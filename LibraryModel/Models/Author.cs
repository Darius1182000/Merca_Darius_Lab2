namespace LibraryModel.Models;
using Microsoft.EntityFrameworkCore;

public class Author
{
    public int ID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
   // public Book Book { get; set; }
    public ICollection<Book>? Books { get; set; }


}
