namespace LibraryModel.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

public class Customer
{

    public int? CustomerID { get; set; }
    public string? Name { get; set; }
    public string? Adress { get; set; }
    public DateTime BirthDate { get; set; }
    public ICollection<Order>? Orders { get; set; }
    [Display(Name = "City")]
    public int CityID { get; set; }
    public City? City { get; set; } 

}
