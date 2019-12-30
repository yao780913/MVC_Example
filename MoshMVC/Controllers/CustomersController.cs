using MoshMVC.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoshMVC.Controllers
{
    public class CustomersController : Controller
    {
        private EFDbContext _dbContext;
        public CustomersController()
        {
            _dbContext = new EFDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            return View(_dbContext.Customers.Include(c => c.MembershipType));
        }

        public ActionResult Detail(int id)
        {
            var customer = _dbContext.Customers
                .Include(c => c.MembershipType)
                .FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}