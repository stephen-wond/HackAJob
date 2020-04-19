using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JWTAuth.Model;

namespace JWTAuth.Data
{
    public class PhonebookContext : DbContext
    {
        public PhonebookContext (DbContextOptions<PhonebookContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    FirstName = "Steve",
                    LastName = "Wond",
                    PhoneNumber = "09876543210"
                }
            );
            modelBuilder.Entity<UserLogin>().HasData(
                new UserLogin {
                    Id = 1,
                    Username = "Steve",
                    Password = "123",
                    EmailAddress = "Steve@Steve.com" }
            );
        }

        public DbSet<JWTAuth.Model.Contact> Contact { get; set; }
        public DbSet<JWTAuth.Model.UserLogin> Login { get; set; }
    }
}
