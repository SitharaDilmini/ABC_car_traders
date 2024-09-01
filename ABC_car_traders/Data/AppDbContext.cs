using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ABC_Car_Traders.Models;
using ABC_car_traders.Models;

namespace ABC_Car_Traders.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarSparePart> CarSpareParts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasKey(a => a.Id)
                .Property(a => a.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id)
                .Property(u => u.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            modelBuilder.Entity<Car>()
                .HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);



            modelBuilder.Entity<Car>()
                .HasRequired(c => c.CarMake)
                .WithMany()
                .HasForeignKey(c => c.CarMakeId)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<CarMake>()
                .HasKey(cm => cm.Id)
                .Property(cm => cm.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);



            modelBuilder.Entity<CarMake>()
                .HasRequired(cm => cm.CarModel)
                .WithMany()
                .HasForeignKey(cm => cm.CarModelId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarModel>()
                .HasKey(cm => cm.Id)
                .Property(cm => cm.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);



            modelBuilder.Entity<CarSparePart>()
                .HasKey(csp => csp.Id)
                .Property(csp => csp.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);



            modelBuilder.Entity<CarSparePart>()
                .HasRequired(csp => csp.CarMake)
                .WithMany()
                .HasForeignKey(csp => csp.CarMakeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id)
                .Property(o => o.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            modelBuilder.Entity<Order>()
                .HasOptional(o => o.Car)
                .WithMany()
                .HasForeignKey(o => o.CarId)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CarOrder>()
            //    .HasKey(co => co.Id)
            //    .Property(co => co.Id)
            //    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            //modelBuilder.Entity<CarOrder>()
            //    .HasRequired(co => co.Car)
            //    .WithMany()
            //    .HasForeignKey(co => co.CarId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CarOrder>()
            //    .HasRequired(co => co.User)
            //    .WithMany()
            //    .HasForeignKey(co => co.UserId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<SparePartOrder>()
            //    .HasKey(spo => spo.Id)
            //    .Property(spo => spo.Id)
            //    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            //modelBuilder.Entity<SparePartOrder>()
            //    .HasRequired(spo => spo.CarSparePart)
            //    .WithMany()
            //    .HasForeignKey(spo => spo.CarSparePartId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<SparePartOrder>()
            //    .HasRequired(spo => spo.User)
            //    .WithMany()
            //    .HasForeignKey(spo => spo.UserId)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<CartItem>()
                .HasKey(ci => ci.Id)
                .Property(ci => ci.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);



            modelBuilder.Entity<CartItem>()
                .HasOptional(ci => ci.Car)
                .WithMany()
                .HasForeignKey(ci => ci.CarId)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<CartItem>()
                .HasOptional(ci => ci.SparePart)
                .WithMany()
                .HasForeignKey(ci => ci.SparePartId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CartItem>()
                .HasRequired(ci => ci.User)
                .WithMany()
                .HasForeignKey(ci => ci.UserId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
