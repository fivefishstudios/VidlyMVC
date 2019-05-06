using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        // need to setup context for database access
        private MyDBContext _context;

        public CustomersController()
        {
            _context = new MyDBContext();
        }

        // GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            // if customer not found, i.e. invalid id number
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // else return the found customer record
            return customer;
        }

        // POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            // validate model
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // add this new record in memory
            _context.Customers.Add(customer);
            // write changes to database
            _context.SaveChanges();

            return customer;
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            // validate model
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // find the matching customer based on id number
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            // if customer not found, i.e. invalid id number
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // everything is good, update customer
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            // save the changes
            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            // check if customer is found, i.e. valid id
            // find the matching customer based on id number
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            // if customer not found, i.e. invalid id number
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // delete this record in memory
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}