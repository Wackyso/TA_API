using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Microsoft.EntityFrameworkCore;
using Npgsql.TypeHandlers.DateTimeHandlers;

namespace TA_API.Models
{
    public class ThAppContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dialog>().HasKey(u => new { u.login, u.dialog_id});
            modelBuilder.Entity<Message>().HasKey(u => new { u.login, u.send_time});
        }

        public ThAppContext()
        {
            Database.EnsureCreated();
            
        }


        public DbSet<User> users { get; set; }
        public DbSet<Dialog> dialogs { get; set; }
        public DbSet<Message> messages { get; set; }


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

    public class Dialog
    {
        [Key]
        public string login { get; set; }
        [Key]
        public int dialog_id { get; set; }
        public string interlocutor { get; set; }

    }

    public class Message
    {
        [Key]
        public string login { get; set; }
        public string text { get; set; }
        public int dialog_id  { get; set; }
        [Key]
        public string send_time { get; set; }

    }

    public class Message_for_resp
    {
        
        public int login { get; set; }
        public string text { get; set; }
        
        
        public DateTime send_time { get; set; }

    }
}