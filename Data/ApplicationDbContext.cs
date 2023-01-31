using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<IPN> IPNs { get; set; }
        public DbSet<MyRegisteredUser> MyRegisteredUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RoleVM> RoleVM { get; set; } = default!;


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
               base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product 
                {
                    ID = 1, ProductName = "Red Cards", 
                    Description = "Are you looking for a fun and affordable way to " +
                                             "pass the time? Look no further than our high-" +
                                             "quality deck of cards! At only $3.79, this deck " +
                                             "of cards is an excellent value.", 
                    Price = "3.79", 
                    Currency = "CAD", 
                    Image = "deckofcards.png"
                },
                new Product
                {
                    ID = 2, 
                    ProductName = "Extra Ace", 
                    Description = "Are you tired of being caught without an ace up " +
                                "your sleeve? Well, have no fear! Our special deck " +
                                "of cards comes with an extra ace, so you can " +
                                "always have the upper hand. And at just $4.95, " +
                                "it's a steal!", 
                    Price = "4.95", 
                    Currency = "CAD", 
                    Image = "fiveaces.jpg"
                },
                new Product
                {
                    ID = 3, ProductName = "Black Deck", 
                    Description = "Upgrade your card game with our premium black-" +
                                "styled deck of cards. Made with high-quality " +
                                "materials and featuring a sleek black design. At " +
                                "just $7.79, it's a small price to pay to make a " +
                                "big statement!",
                    Price = "7.79",
                    Currency = "CAD",
                    Image = "blackdeck.jpeg"
                });
        }
    }

    // Instant Payment Notification
    public class IPN
    {
        // This lets you link the request to paypal with the response.
        public string custom { get; set; }

        [Display(Name = "ID")]
        [Key] // Define primary key.
        public string paymentID { get; set; }
        public string cart { get; set; }
        public string create_time { get; set; }

        // Payer data.
        public string payerID { get; set; }
        public string payerFirstName { get; set; }
        public string payerLastName { get; set; }
        public string payerMiddleName { get; set; }
        public string payerEmail { get; set; }
        public string payerCountryCode { get; set; }
        public string payerStatus { get; set; }

        // Payment data.
        public string amount { get; set; }
        public string currency { get; set; }
        public string intent { get; set; }
        public string paymentMethod { get; set; }
        public string paymentState { get; set; }
    }

}