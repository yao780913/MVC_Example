using MoshMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoshMVC.Controllers
{
    public class CustomersController : Controller
    {
        readonly IEnumerable<Customer> customers;

        public CustomersController()
        {
            customers = new List<Customer>() 
            {
                new Customer{ Id = 1, Name = "Bill"},
                new Customer{ Id = 2, Name = "William"}
            };
        }
        // GET: Customers
        public ActionResult Index()
        {
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}