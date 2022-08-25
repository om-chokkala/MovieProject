using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieProject.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
 }
}