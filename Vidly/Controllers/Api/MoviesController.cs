using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using DevExtensions;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
   public class MoviesController : ApiController
   {
      private ApplicationDbContext context;

      public MoviesController()
      {
         context = new ApplicationDbContext();
      }

      public IHttpActionResult GetMovies(string query = null)
      {
         var movieQuery = context
            .Movies
            .Include(r => r.Genre)
            .Where(r => r.NumberAvailable > 0);

         if (!string.IsNullOrWhiteSpace(query))
         {
            movieQuery = movieQuery.Where(r => r.Name.Contains(query));
         }

         var movieDtos = movieQuery
            .ToList()
            .Select(Mapper.Map<Movie, MovieDto>);
         return Ok(movieDtos);
      }

      public IHttpActionResult GetMovie(int id)
      {
         var movie = context
            .Movies
            .Include(r => r.Genre)
            .SingleOrDefault(r => r.Id == id);
         if (movie.IsNull())
            return NotFound();
         return Ok(Mapper.Map<Movie, MovieDto>(movie));
      }

      [HttpPost]
      [Authorize(Roles = RoleName.CanManageMovies)]

      public IHttpActionResult CreateMovie(MovieDto movieDto)
      {
         if (!ModelState.IsValid)
            return BadRequest();

         var movie = Mapper.Map<MovieDto, Movie>(movieDto);
         context.Movies.Add(movie);
         context.SaveChanges();
         movieDto.Id = movie.Id;
         return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
      }

      [HttpPut]
      [Authorize(Roles = RoleName.CanManageMovies)]
      public IHttpActionResult UpdateCustomer(int id, MovieDto movieDto)
      {
         if (!ModelState.IsValid)
            return BadRequest();

         var movieInDb = context.Movies.SingleOrDefault(r => r.Id == id);
         if (movieInDb.IsNull())
            return NotFound();

         Mapper.Map(movieDto, movieInDb);

         context.SaveChanges();
         return Ok();
      }

      [HttpDelete]
      [Authorize(Roles = RoleName.CanManageMovies)]
      public IHttpActionResult DeleteCustomer(int id)
      {
         var movieInDb = context.Movies.SingleOrDefault(r => r.Id == id);
         if (movieInDb.IsNull())
            return NotFound();
         context.Movies.Remove(movieInDb);
         context.SaveChanges();
         return Ok();
      }
   }
}