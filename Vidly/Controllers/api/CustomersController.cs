using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Vidly.Models;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;

namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _customers;

        public CustomersController()
        {
            _customers = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customersList = _customers.Customer.Include(c => c.membershipType).ToList().Select(Mapper.Map<Customers, CustomerDto>);
            return customersList;
        }
        // Get /api/customers/1
        public IHttpActionResult GetCustomer(int? id)
        {
            var customer = _customers.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customers, CustomerDto>(customer));
        }
        // Get /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            var customer = Mapper.Map<CustomerDto, Customers>(customerdto);
            if (!ModelState.IsValid)
                return BadRequest();
            _customers.Customer.Add(customer);
            _customers.SaveChanges();

            customerdto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerdto);
        }
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var target = _customers.Customer.SingleOrDefault(c => c.Id == id);
            if (target == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerdto, target);
            _customers.SaveChanges();
        }
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var target = _customers.Customer.SingleOrDefault(c => c.Id == id);
            if (target == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _customers.Customer.Remove(target);
            _customers.SaveChanges();
        }
    }
}
