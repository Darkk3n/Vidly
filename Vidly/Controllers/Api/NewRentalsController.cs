using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
   public class NewRentalsController : ApiController
   {
      private ApplicationDbContext context;

      public NewRentalsController()
      {
         context = ApplicationDbContext.Create();
      }

      [HttpPost]
      public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
      {
         var customer = context.Customers.Single(r => r.Id == newRental.CustomerId);

         var movies = context.Movies.Where(r => newRental.MovieIds.Contains(r.Id));

         foreach (var movie in movies)
         {
            if (movie.NumberAvailable == 0)
               return BadRequest("Movie is not available.");

            movie.NumberAvailable--;
            var rental = new Rental
            {
               Customer = customer,
               Movie = movie,
               DateRented = DateTime.Now
            };
            context.Rentals.Add(rental);
         }
         context.SaveChanges();
         return Ok();
      }
   }
}
