using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VehicleContext : DbContext
    {
        public DbSet<VehicleMake> Makes { get; set; }
        public DbSet<VehicleModel> Models { get; set; }

        protected readonly IConfiguration Configuration;
        public VehicleContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("VehicleDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<VehicleModel>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<VehicleMake>().HasData(
                new VehicleMake { Id = 1, Name = "Volkswagen", Abrv = "Vw" },
                new VehicleMake { Id = 2, Name = "Dr. Ing. h. c. F. Porsche AG", Abrv = "Porsche" },
                new VehicleMake { Id = 3, Name = "Toyota Motor Corporation", Abrv = "Toyota" },
                new VehicleMake { Id = 4, Name = "Mazda" },
                new VehicleMake { Id = 5, Name = "Hyundai Motor Company", Abrv = "Hyundai"}
                );
            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel { Id = 1, Name = "Golf Mk3", Abrv = "Golf III", VehicleMakeId = 1 },
                new VehicleModel { Id = 2, Name = "924", VehicleMakeId = 2 },
                new VehicleModel { Id = 3, Name = "Celica", VehicleMakeId = 3 },
                new VehicleModel { Id = 4, Name = "RX-7", VehicleMakeId = 4 },
                new VehicleModel { Id = 5, Name = "i30 N", VehicleMakeId = 5 }
                );
        }

    }
}
