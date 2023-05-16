using Microsoft.EntityFrameworkCore;
using QuanLyLamNghiep.Models;

namespace QuanLyLamNghiep.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ChuongMuc> ChuongMucs { get; set; }
        public DbSet<DieuKhoan> DieuKhoans { get; set; }
    }
}
