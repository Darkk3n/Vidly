using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
   public class MoviesController : Controller
   {
      private ApplicationDbContext context;

      public MoviesController()
      {
         context = new ApplicationDbContext();
      }
      // GET: Movies
      public ViewResult Index()
      {
         if (User.IsInRole(RoleName.CanManageMovies))
         {
            return View("List");
         }
         return View("ReadOnlyList");
      }

      public ActionResult Details(int id)
      {
         var movie = context
            .Movies
            .Include(r => r.Genre)
            .SingleOrDefault(r => r.Id == id);
         if (movie == null)
            return HttpNotFound();
         return View(movie);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize(Roles = RoleName.CanManageMovies)]
      public ActionResult Save(Movie movie)
      {
         if (movie.Id == 0)
         {
            movie.DateAdded = DateTime.Now;
            context.Movies.Add(movie);
         }
         else
         {
            var movieInDb = context.Movies.Single(r => r.Id == movie.Id);
            movieInDb.Name = movie.Name;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;
         }
         context.SaveChanges();
         return RedirectToAction("Index", "Movies");
      }

      [Authorize(Roles = RoleName.CanManageMovies)]
      public ActionResult Edit(int id)
      {
         var movie = context.Movies.SingleOrDefault(r => r.Id == id);
         if (movie == null)
         {
            return HttpNotFound();
         }
         var viewModel = new MovieFormViewModel(movie)
         {
            Genres = context.Genres.ToList()
         };
         return View("MovieForm", viewModel);
      }

      [Authorize(Roles = RoleName.CanManageMovies)]
      public ActionResult New()
      {
         var viewModel = new MovieFormViewModel
         {
            Genres = context.Genres.ToList()
         };
         return View("MovieForm", viewModel);
      }
   }
}