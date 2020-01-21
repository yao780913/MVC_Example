using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoshMVC.Models;
using System.Data.Entity;

namespace MoshMVC.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private EFDbContext _dbContext;
        public CustomersController()
        {
            _dbContext = new EFDbContext();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_dbContext.Customers.Include(c => c.MembershipType));
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var customer = _dbContext.Customers
                .Include(c => c.MembershipType)
                .FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }


    }
}
