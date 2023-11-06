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
            modelBuilder.Entity<VehicleMake>()
            .HasMany(e => e.Models)
            .WithOne(e => e.VehicleMake)
            .HasForeignKey(e => e.VehicleMakeId)
            .IsRequired();

            modelBuilder.Entity<VehicleModel>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<VehicleMake>().HasData(
                new VehicleMake(1, "Volkswagen", "Vw"),
                new VehicleMake(2, "Dr. Ing. h. c. F. Porsche AG", "Porsche"),
                new VehicleMake(3, "Toyota Motor Corporation", "Toyota"),
                new VehicleMake(4, "Mazda"),
                new VehicleMake(5, "Hyundai Motor Company", "Hyundai")
                );
            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel(1, "Golf Mk3", "Golf III", 1),
                new VehicleModel(2, "924", 2),
                new VehicleModel(3, "Celica", 3),
                new VehicleModel(4, "RX-7", 4),
                new VehicleModel(5, "i30 N", 5)
                );
        }

    }
}
