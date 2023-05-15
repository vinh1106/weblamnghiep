using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication4.Models
{
    public partial class DbLamNghiepConnectApp : DbContext
    {
        public DbLamNghiepConnectApp()
            : base("name=DbLamNghiepConnectApp")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<ChuongMuc> ChuongMucs { get; set; }
        public virtual DbSet<DieuKhoan> DieuKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.type)
                .IsUnicode(false);
        }
    }
}
