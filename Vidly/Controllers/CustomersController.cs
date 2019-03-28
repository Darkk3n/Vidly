using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;
using DevExtensions;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
   public class CustomersController : Controller
   {
      private ApplicationDbContext context;

      public CustomersController()
      {
         context = new ApplicationDbContext();
      }

      public ViewResult Index()
      {
         if (MemoryCache.Default["Genres"] == null)
         {
            MemoryCache.Default["Genres"] = context.Genres.ToList();
         }
         var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

         return View();
      }

      public ActionResult Details(int id)
      {
         var customer = context
            .Customers
            .Include(r => r.MembershipType)
            .SingleOrDefault(r => r.Id == id);
         if (customer.IsNull())
            return HttpNotFound();
         return View(customer);
      }

      public ActionResult New()
      {
         var membershipTypes = context.MembershipTypes.ToList();
         var viewModel = new CustomerFormViewModel
         {
            Customer = new Customer(),
            MembershipTypes = membershipTypes
         };
         return View("CustomerForm", viewModel);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Save(Customer customer)
      {
         if (!ModelState.IsValid)
         {
            var viewModel = new CustomerFormViewModel
            {
               Customer = customer,
               MembershipTypes = context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
         }
         if (customer.Id == 0)
         {
            context.Customers.Add(customer);
         }
         else
         {
            var existingCustomer = context.Customers.Include(r => r.MembershipType).Single(r => r.Id == customer.Id);
            existingCustomer.Name = customer.Name;
            existingCustomer.MembershipTypeId = customer.MembershipTypeId;
            existingCustomer.BirthDate = customer.BirthDate;
            existingCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
         }
         context.SaveChanges();
         return RedirectToAction("Index", "Customers");
      }

      public ActionResult Edit(int id)
      {
         var customer = context.Customers.SingleOrDefault(r => r.Id == id);
         if (customer.IsNull())
            return HttpNotFound();
         var viewModel = new CustomerFormViewModel
         {
            Customer = customer,
            MembershipTypes = context.MembershipTypes.ToList()
         };
         return View("CustomerForm", viewModel);
      }

      protected override void Dispose(bool disposing)
      {
         context.Dispose();
      }
   }
}