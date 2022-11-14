using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data // Data folder is created manually to house anything related to data.
{
    public class StoreContext : DbContext // DbContext class comes from Entity Framework. The creates a session or gateway to the database. It manages connection to the database. It can contain 1 or more DbSet, which are tables in the database. To get query the db we use a Linq query, written in C#. DbContext translates Linq to SQL. Then returns the query results already mapped back to our Entity. This line "derives" from the DbContext in Entity framework.
    {
        // this constructor will allow us to pass options to base class, which is DbContext
        public StoreContext(DbContextOptions options) : base(options) // the option that we need to pass is the database connection string
        {

        }
        // This creates tables (dbset) for class products, the name of the table is Products
        public DbSet<Product> Products { get; set; }
    }
}