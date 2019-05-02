using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly MyDBContext _context;

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

        public ActionResult View(int id)
        {
            // NOTE: This works, using List methods
            //var customers = GetAllCustomers().ToList();
            //Customer customer = customers.Find(x => x.Id == Id);

            // NOTE: This also works, without using a List<> but using IEnumerable methods
            var customers = GetAllCustomers().Include(c => c.MembershipType);
            Customer customer = customers.SingleOrDefault(c => c.Id == id);

            return View(customer);
        }

        private IQueryable<Customer> GetAllCustomers()
        {
            return _context.Customers;
        }

        // GET
        public ActionResult New()
        {
            // we need to bring in MembershipType table so we can display it in a dropdown box.
            List<MembershipType> membershipTypes = _context.MembershipType.ToList();

            // but we also need to pass the Customer model
            // so we need to create a new ViewModel combining Customer model and membershipTypes
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)   // POST method for add new customer form
        {
            _context.Customers.Add(customer);           // add this model to Customers
            _context.SaveChanges();                     // physically write data to database

            return RedirectToAction("Index", "Customers");  // we redirect to main Customers page
        }
    }
}