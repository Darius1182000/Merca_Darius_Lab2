﻿using Grpc.Net.Client;
using GrpcCustomersService;
using Microsoft.AspNetCore.Mvc;
//using LibraryModel.Models;


namespace Merca_Darius_Lab2.Controllers
{
    public class CustomersGrpcController : Controller
    {
        private readonly GrpcChannel channel;
        public CustomersGrpcController()
        {

            channel = GrpcChannel.ForAddress("https://localhost:7023");

        }
        [HttpGet]
        public IActionResult Index()
        {
            
            var client = new CustomerService.CustomerServiceClient(channel);          
            
            CustomerList cust = client.GetAll(new Empty());
            return View(cust);
        }
        //-----------------------------------------------------------------------------------
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new
                CustomerService.CustomerServiceClient(channel);
                var createdCustomer = client.Insert(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
    }
}
