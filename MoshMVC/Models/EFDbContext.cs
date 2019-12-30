using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoshMVC.Models
{
    public class EFDbContext: DbContext
    {
        public EFDbContext(): base("ConnStr")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<EFDbContext>());
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
    }
}