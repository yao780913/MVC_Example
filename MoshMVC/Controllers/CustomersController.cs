using MoshMVC.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoshMVC.Controllers
{
    public partial class CustomersController : Controller
    {
        private EFDbContext _dbContext;
        public CustomersController()
        {
            _dbContext = new EFDbContext();
        }
        // GET: Customers
        public virtual ActionResult Index()
        {
            
            return View(_dbContext.Customers.Include(c => c.MembershipType));
        }

        public virtual ActionResult Detail(int id)
        {
            var customer = _dbContext.Customers
                .Include(c => c.MembershipType)
                .FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult EditPartial(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            ViewBag.MembershipTypeList = new SelectList(_dbContext.MembershipTypes, nameof(MembershipType.Id), nameof(MembershipType.Name));
            if (customer == null)
                return HttpNotFound();

            return PartialView("_EditPartial", customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPartial(Customer customer)
        {
            var customerInDb = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);

            if (customerInDb == null)
                return HttpNotFound();

            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.Name = customer.Name;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}