

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace QuanLyBanHang.Data
{

    public class QLBHDbContext : DbContext
    {
        public QLBHDbContext(DbContextOptions<QLBHDbContext> options)
            : base(options)
        {
        }

        // Thêm constructor này cho design-time
        public QLBHDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Thay YOUR_CONNECTION_STRING bằng connection string thực tế
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["QLBHConnection"].ConnectionString);
            }
        }

        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<HangSanXuat> HangSanXuat { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<HoaDon_ChiTiet> HoaDon_ChiTiet { get; set; }
    }
}


