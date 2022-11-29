using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryModel.Data;
using LibraryModel.Models;
//using Merca_Darius_Lab2.Data;
//using Merca_Darius_Lab2.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;


namespace Merca_Darius_Lab2.Controllers
{
    public class CustomersController : Controller
    {
        private readonly LibraryContext _context;
        private string _baseUrl = "https://localhost:7024/api/Customers";
        //7024https,5024http
        public CustomersController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_baseUrl);

            if (response.IsSuccessStatusCode)
            {
                var customers = JsonConvert.DeserializeObject<List<Customer>>(await response.Content.ReadAsStringAsync());
                var libraryContext = _context.Customers.Include(cn => cn.City);

                // return View(customers);
                return View(await libraryContext.ToListAsync());

            }
            return NotFound();

        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var customer = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
                if (_context.Customers == null)
                {
                    return NotFound();
                }
                var city = await _context.Customers
                    .Include(a => a.City)
                    .FirstOrDefaultAsync(m => m.CustomerID == id);
                if (city == null)
                {
                    return NotFound();
                }
                return View(city);
            }
            /*    return View(customer);
            }*/
            return NotFound();
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            var city = _context.Cities.Select(x => new
            {
                x.ID,
                x.CityName
            });
            ViewData["CityID"] = new SelectList(_context.Cities, "ID", "CityName");
            return View();

            //ViewBag.CityID = new SelectList(_context.Cities, "ID", "CityName");
            //return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,Name,Adress,BirthDate,CityID")] Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            try
            {
                var client = new HttpClient();
                string json = JsonConvert.SerializeObject(customer);
                var response = await client.PostAsync(_baseUrl,new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to create record: { ex.Message}");
            }

            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityID"] = new SelectList(_context.Authors, "ID", "ID", customer.CityID);
            return View(customer);
            //  ViewBag.CityID = new SelectList(_context.Cities, "ID", "CityName", customer.CityID);
            //  return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var customer = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
                var city = await _context.Customers.FindAsync(id);
                if (city == null || customer == null)
                {
                    return NotFound();
                }
                
                
                ViewBag.CityID = new SelectList(_context.Cities, "ID", "CityName");
                return View(city);
            }

            return new NotFoundResult();
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerID,Name,Adress,BirthDate,CityID")] Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            var client = new HttpClient();
            string json = JsonConvert.SerializeObject(customer);
            var response = await client.PutAsync($"{_baseUrl}/{customer.CustomerID}", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
           
            ViewBag.CityID = new SelectList(_context.Cities, "ID", "CityName", customer.CityID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var customer = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
                var city = await _context.Customers
                    .Include(a => a.City)
                    .FirstOrDefaultAsync(m => m.CustomerID == id);
                if (city == null)
                {
                    return NotFound();
                }
                return View(city);
            }
            return new NotFoundResult();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([Bind("CustomerID")] Customer customer)
        {
            try
            {
                var client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete,$"{_baseUrl}/{customer.CustomerID}")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json")
                };
                var response = await client.SendAsync(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to delete record:{ ex.Message}");
            }
            return View(customer);
        }
    
    
    // POST: Customers/Delete/5
    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'LibraryContext.Customers'  is null.");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}
