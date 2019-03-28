using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using DevExtensions;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
   public class CustomersController : ApiController
   {
      private ApplicationDbContext context;

      public CustomersController()
      {
         context = new ApplicationDbContext();
      }

      public IHttpActionResult GetCustomers(string query = null)
      {
         var customerQuery = context
            .Customers
            .Include(r => r.MembershipType);

         if (query.HasValue())
         {
            customerQuery = customerQuery.Where(r => r.Name.Contains(query));
         }

         var customerDtos = customerQuery
            .ToList()
            .Select(Mapper.Map<Customer, CustomerDto>);
         return Ok(customerDtos);
      }

      public IHttpActionResult GetCustomer(int id)
      {
         var customer = context
            .Customers
            .Include(r => r.MembershipType)
            .SingleOrDefault(r => r.Id == id);
         if (customer.IsNull())
            return NotFound();
         return Ok(Mapper.Map<Customer, CustomerDto>(customer));

      }

      [HttpPost]
      public IHttpActionResult CreateCustomer(CustomerDto customerDto)
      {
         if (!ModelState.IsValid)
            return BadRequest();

         var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
         context.Customers.Add(customer);
         context.SaveChanges();
         customerDto.Id = customer.Id;
         return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
      }

      [HttpPut]
      public void UpdateCustomer(int id, CustomerDto customerDto)
      {
         if (!ModelState.IsValid)
            throw new HttpResponseException(HttpStatusCode.BadRequest);

         var customerInDb = context.Customers.SingleOrDefault(r => r.Id == id);
         if (customerInDb.IsNull())
            throw new HttpResponseException(HttpStatusCode.NotFound);

         Mapper.Map(customerDto, customerInDb);

         context.SaveChanges();
      }

      [HttpDelete]
      public void DeleteCustomer(int id)
      {
         var customerInDb = context.Customers.SingleOrDefault(r => r.Id == id);
         if (customerInDb.IsNull())
            throw new HttpResponseException(HttpStatusCode.NotFound);
         context.Customers.Remove(customerInDb);
         context.SaveChanges();
      }
   }
}