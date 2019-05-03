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
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)   // POST method for add new customer form
        {
            // if customer has no id, this is a new customer and we Add to database
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);           // add this model to Customers
            }
            else
            {
                // it's existing customer and we Update customer information
                // retrieve existing record, make changes, then save
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);  // use Single, not SingleOrDefault
                // update values
                // TryUpdateModel(customerInDb);  // with security holes? updates all fields in database

                // alternative: update manually the fields we only need changing
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();                     // physically write data to database

            return RedirectToAction("Index", "Customers");  // we redirect to main Customers page
        }

        public ActionResult Edit(int id)
        {
            // get this particular customer from database
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            // check for not found
            if (customer == null)
            {
                return HttpNotFound();
            }

            // create CustomerFormViewModel for our edit form
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = _context.MembershipType.ToList(),
                Customer = customer
            };

            // customer found, return to the new page
            return View("CustomerForm", viewModel);
        }
    }
}