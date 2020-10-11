using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Microsoft.EntityFrameworkCore;

namespace TA_API.Models
{
    public class ThAppContext : DbContext
    {
        public ThAppContext()
        {
            Database.EnsureCreated();
            
        }

        public DbSet<User> users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ThirdAppDB;Username=postgres;Password=");
        }
    }

    public class User
    {
        [Key]
        public string login { get; set; }
        public string password { get; set; }

    }
}