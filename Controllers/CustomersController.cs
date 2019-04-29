using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> _customers;
        public CustomersController()
        {
            _customers = new List<Customer>()
            {
                new Customer() { Id=1, Name="Roberto Gonza", City="Brentwood" },
                new Customer() { Id=2, Name="John Doe", City="Nashville" },
                new Customer() { Id=49, Name="Mary Poppins", City="Franklin"}
            };
            
        }
        // GET: Customers
        public ActionResult Index()
        {
                
            return View(_customers);
        }

        public ActionResult View(int Id)
        {
            Customer customer = _customers.Find(x => x.Id == Id);
            return View(customer);
        }
    }
}