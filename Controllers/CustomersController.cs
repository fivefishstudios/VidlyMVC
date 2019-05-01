using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private MyDBContext _context;

        public CustomersController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetAllCustomers().Include(c => c.MembershipType);
            return View(customers);
        }

        public ActionResult View(int Id)
        {
            // NOTE: This works, using List methods
            //var customers = GetAllCustomers().ToList();
            //Customer customer = customers.Find(x => x.Id == Id);

            // NOTE: This also works, without using a List<> but using IEnumerable methods
            var customers = GetAllCustomers().Include(c => c.MembershipType);
            Customer customer = customers.SingleOrDefault( c => c.Id == Id);
                 
            return View(customer);
        }


        private IQueryable<Customer> GetAllCustomers()
        {
            return _context.Customers;
        }


    }
}