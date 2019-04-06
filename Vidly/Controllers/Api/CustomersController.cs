using System;
using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Controllers.Api 
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDto = _context.Customers.Include(c=>c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDto);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.CustomerId = customer.CustomerId;
            return Created(new Uri(Request.RequestUri+"/"+customer.CustomerId),customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerIndDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerIndDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerIndDb);
           _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerIndDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerIndDb == null)
                return NotFound();

            _context.Customers.Remove(customerIndDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
