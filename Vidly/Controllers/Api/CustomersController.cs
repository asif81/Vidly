using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        private IHttpActionResult GetCustomers()
        {
            var customerDto = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDto);
        }

        // GET /api/customers/1
        private IHttpActionResult GetCustomer(int Id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.CustomerId == Id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers
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

        // PUT /api/Customers/1
        public IHttpActionResult UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerIndDb = _context.Customers.SingleOrDefault(c => c.CustomerId == Id);
            if (customerIndDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerIndDb);
           _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/Customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerIndDb = _context.Customers.SingleOrDefault(c => c.CustomerId == Id);
            if (customerIndDb == null)
                return NotFound();

            _context.Customers.Remove(customerIndDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
