using CrudeMobileApp.Model;
using CrudeMobileApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudeMobileApp.Shared
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<DetailOrder> DetailOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "app.db")}");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = "CL00001", CompanyName = "La récrée des petits bouts", ContactName = "TAUREAU", Address = "27 rue des fleurs", City = "CHARTRES", Region = "EURE-ET-LOIR", PostalCode = "28000", Country = "FR", Phone = "123455" },
                new Customer { CustomerId = "CL00002", CompanyName = "TARDIEU Antoinette", ContactName = "Keshav", Address = "11 Avenue du coin du bois", City = "BOISEMONT", Region = "VAL-D OISE", PostalCode = "95000", Country = "FR", Phone = "123455" },
                new Customer { CustomerId = "CL00003", CompanyName = "RAVIN Odile", ContactName = "Taurah", Address = "5 rue Mond", City = "BOBIGNY", Region = "SEINE-ST-DENIS", PostalCode = "93000", Country = "FR", Phone = "123455" },
                new Customer { CustomerId = "CL00004", CompanyName = "CRECHE LES LUTINS", ContactName = "TONGSAVARN", Address = "44 rue Turenne", City = "GRENOBLE", Region = "ISERE", PostalCode = "38000", Country = "FR", Phone = "123455" },
                new Customer { CustomerId = "CL00005", CompanyName = "LUDOTHEQUE ODYSSEE", ContactName = "VOEGEL", Address = "35 rue Marbeuf", City = "GRENOBLE", Region = "ISERE", PostalCode = "38000", Country = "FR", Phone = "123455" },
                new Customer { CustomerId = "CL00006", CompanyName = "IKEO", ContactName = "PLESSIS", Address = "2 rue Gloxin", City = "STRASBOURG", Region = "BAS-RHIN", PostalCode = "67000", Country = "FR", Phone = "123455" },
                new Customer { CustomerId = "CL00007", CompanyName = "LUDO CLUB", ContactName = "ROUSSEAU", Address = "13 rue source", City = "MOLSHEIM", Region = "BAS-RHIN", PostalCode = "67120", Country = "FR", Phone = "123455" },
                new Customer { CustomerId = "CL00008", CompanyName = "MOREL", ContactName = "MOREL", Address = "128 route Guillon", City = "COUBLEVIE", Region = "ISERE", PostalCode = "38500", Country = "FR", Phone = "123455" }
            );

            // Seed Orders
            modelBuilder.Entity<Order>().HasData(
             new Order
             {
                 OrderId = 1,
                 CustomerId = "CL00001",
                 OrderDate = new DateTime(2023, 10, 15),
                 ShippingDate = new DateTime(2023, 10, 18),
                 ShippingName = "Alice",
                 ShippingAddress = "123 Main St",
                 ShippingCity = "Metropolis",
                 ShippingRegion = "IL",
                 ShippingPostalCode = "60000",
                 ShippingCountry = "US",
                 ShippingPhone = "123-456-7890"
             },
             new Order
             {
                 OrderId = 2,
                 CustomerId = "CL00002",
                 OrderDate = new DateTime(2023, 10, 16),
                 ShippingDate = new DateTime(2023, 10, 19),
                 ShippingName = "Bob",
                 ShippingAddress = "456 Elm St",
                 ShippingCity = "Smallville",
                 ShippingRegion = "KS",
                 ShippingPostalCode = "67000",
                 ShippingCountry = "US",
                 ShippingPhone = "987-654-3210"
             }
         );

            modelBuilder.Entity<Product>().HasData(
               new Product { ProductId = "ANIM0001", ProductName = "ANIMATEUR/ANIMATRICE", Description = "ANIMATEUR/ANIMATRICE POUR LA JOURNEE", UnitPrice = 162.00m },
               new Product { ProductId = "ANIM0002", ProductName = "ASSISTANT/ASSISTANTE", Description = "ASSISTANT/ASSISTANTE POUR LA JOURNEE", UnitPrice = 62.71m },
               new Product { ProductId = "ANIM0003", ProductName = "MAGICIEN", Description = "MAGICIEN POUR LA JOURNEE", UnitPrice = 365.80m },
               new Product { ProductId = "ANIM0004", ProductName = "PERE NOEL", Description = "PERE NOEL POUR LA JOURNEE", UnitPrice = 209.03m },
               new Product { ProductId = "ANIM0005", ProductName = "MASCOTTE", Description = "MASCOTTE POUR LA JOURNEE", UnitPrice = 62.71m },
               new Product { ProductId = "ANIM0006", ProductName = "CLOWNS", Description = "CLOWNS POUR LA JOURNEE", UnitPrice = 313.55m },
               new Product { ProductId = "ATEL0001", ProductName = "ATELIER CREATION", Description = "ATELIER CREATION", UnitPrice = 31.35m },
               new Product { ProductId = "ATEL0002", ProductName = "ATELIER BRICOLAGE", Description = "ATELIER BRICOLAGE", UnitPrice = 31.35m },
               new Product { ProductId = "ATEL0003", ProductName = "ATELIER CUISINE", Description = "ATELIER CUISINE", UnitPrice = 31.35m },
               new Product { ProductId = "ATEL0004", ProductName = "ATELIER SCULPTURE SUR BALLONS", Description = "ATELIER SCULPTURE SUR BALLONS", UnitPrice = 31.35m },
               new Product { ProductId = "ATTA0001", ProductName = "ATTACHE-TETINE COEURS", Description = "ATTACHE-TETINE COEURS", UnitPrice = 9.11m },
               new Product { ProductId = "AU0Z0001", ProductName = "AU ZOO AVEC HECTOR LIVRE DE 3 A 6 ANS", Description = "AU ZOO AVEC HECTOR LIVRE DE 3 A 6 ANS", UnitPrice = 7.82m },
               new Product { ProductId = "AVIO0001", ProductName = "AVIONS TELECOMMANDES", Description = "AVIONS TELECOMMANDES", UnitPrice = 55.18m },
               new Product { ProductId = "BARB0001", ProductName = "SET GLADIATEUR", Description = "SET GLADIATEUR", UnitPrice = 14.26m },
               new Product { ProductId = "BARB0002", ProductName = "COFFRET BOUTIQUE MODE", Description = "COFFRET BOUTIQUE MODE", UnitPrice = 22.90m },
               new Product { ProductId = "BARB0003", ProductName = "POUPEE FASHION", Description = "POUPEE FASHION", UnitPrice = 12.78m }
            );
        }
    }
}