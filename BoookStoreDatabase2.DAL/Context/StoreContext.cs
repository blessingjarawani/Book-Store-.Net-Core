using BoookStoreDatabase2.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Dictionary.Dictionary;

namespace BoookStoreDatabase2.DAL.Context
{
    public class StoreContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrderLines> OrderLines { get; set; }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.UseSerialColumns();
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Teminator 2",
                    ImagePath = "",
                    IsActive = true,
                    Price = 2,
                    Quantity = 10
                },
                new Product
                {
                    Id = 2,
                    Name = "Romeo and Juliet",
                    ImagePath = "",
                    IsActive = true,
                    Price = 10,
                    Quantity = 20,
                    ProductType = ProductType.Books
                },
                  new Product
                  {
                      Id = 3,
                      Name = "Mpho Search",
                      ImagePath = "",
                      IsActive = true,
                      Price = 2,
                      Quantity = 20,
                      ProductType = ProductType.Books
                  },
                    new Product
                    {
                        Id = 4,
                        Name = "Mick Mouse",
                        ImagePath = "",
                        IsActive = true,
                        Price = 1,
                        Quantity = 20,
                        ProductType = ProductType.Movies
                    },
                      new Product
                      {
                          Id = 5,
                          Name = "Queen Sono",
                          ImagePath = "",
                          IsActive = true,
                          Price = 20,
                          Quantity = 100,
                          ProductType = ProductType.Movies
                      },
                        new Product
                        {
                            Id = 6,
                            Name = "C# for Dummies",
                            ImagePath = "",
                            IsActive = true,
                            Price = 10,
                            Quantity = 20,
                            ProductType = ProductType.Books
                        }

               );
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var addedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            addedEntities.ForEach(E =>
            {
                if (E.Metadata.FindProperty("CreatedDate") != null)
                {
                    E.Property("CreatedDate").CurrentValue = DateTime.Now;
                }
            });
            var editedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            editedEntities.ForEach(E =>
            {
                if (E.Metadata.FindProperty("CreatedDate") != null)
                    E.Property("CreatedDate").IsModified = false;
                if (E.Metadata.FindProperty("UpdatedDate") != null)
                    E.Property("UpdatedDate").CurrentValue = DateTime.Now;
            });

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
