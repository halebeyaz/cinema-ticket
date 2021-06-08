using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_technologies.Models
{
    public class Context:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=DESKTOP-IADQ3CR\\forcinema;database=corecinema; integrated security=true;");
        }
        public DbSet<Saloon> saloons { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Seat> seats { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Visitor> visitors { get; set; }
    }
}
