using QuanPCChuot.DTO;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanPCChuot.DAL
{
    public partial class Model1 : DbContext
    {
        // public Model1()
        //     : base("name=Model1")
        public Model1()
            : base(@"data source=(LocalDB)\MSSQLLocalDB;initial catalog=QuanPCChuot;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<ItemGroup> ItemGroups { get; set; }
        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.StaffID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Logs)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.StaffID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.ServiceIDs)
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.CostMoney)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Bill>()
                .Property(e => e.SellMoney)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Inventory>()
                .Property(e => e.CostPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Inventory>()
                .Property(e => e.SellPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ItemGroup>()
                .HasMany(e => e.Inventories)
                .WithRequired(e => e.ItemGroup)
                .HasForeignKey(e => e.GroupID)
                .WillCascadeOnDelete(false);
        }
    }
}
