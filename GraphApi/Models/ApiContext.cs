using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphApi.Models
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        //public DbSet<Grooming> Groomings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Chart> Charts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[] {
                new User{id=1, firstName="Shalom", lastName="Shalom", username="admin", password="nimda"}
            });

            //modelBuilder.Entity<Chart>().HasData(new Chart[] {
            //    new Chart{ id=1, cols=new Col(), rows=new Row() },
            //    new Chart(),
            //    new Chart(),
            //});
        }
    }
}
