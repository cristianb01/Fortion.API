using Fortion.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using Pomelo.EntityFrameworkCore.MySql;
using System.Linq;
using System.Threading.Tasks;

namespace Fortion.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseType> WarehouseTypes { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("fortion");
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 4, 21)));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Warehouse>().ToTable("warehouses");
            builder.Entity<Warehouse>().HasKey(w => w.Id);
            builder.Entity<Warehouse>().Property(w => w.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Warehouse>().Property(w => w.ImageUrl).IsRequired();
            builder.Entity<Warehouse>().Property(w => w.Description).IsRequired();
            builder.Entity<Warehouse>().HasOne(w => w.WarehouseType).WithMany(wt => wt.Warehouses);

            builder.Entity<WarehouseType>().HasKey(wt => wt.Id);
            builder.Entity<WarehouseType>().Property(wt => wt.Length).IsRequired();
            builder.Entity<WarehouseType>().Property(wt => wt.Width).IsRequired();

            builder.Entity<WarehouseType>().HasData(
                new WarehouseType {Id = 1, Length = 4, Width = 4 },
                new WarehouseType { Id = 2, Length = 1, Width = 1 },
                new WarehouseType { Id = 3, Length = 2, Width = 2 },
                new WarehouseType { Id = 4, Length = 3, Width = 3 },
                new WarehouseType { Id = 5, Length = 5, Width = 5 }
            );

            builder.Entity<Warehouse>().HasData(
                new Warehouse { Id = 1, Description = "Beautiful warehouse", ImageUrl = "https://www.prologis.com/sites/corporate/files/images/2019/09/large-ontario_dc9_3_11.jpg", WarehouseTypeId = 1 },
                new Warehouse { Id = 2, Description = "Another beautiful warehouse", ImageUrl = "https://www.americanwarehouses.com/hubfs/AmericanWarehouses_Blog_TheBestApproachToLeasingWarehouseSpace.jpg", WarehouseTypeId = 4 },
                new Warehouse { Id = 3, Description = "Big warehouse", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFUF7sF6E0m-8enGRPS0RHn-FbCraPQLkeeg&usqp=CAU", WarehouseTypeId = 3 }
                );
        }
    }
}
