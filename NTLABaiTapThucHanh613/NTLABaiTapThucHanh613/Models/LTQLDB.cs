using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NTLABaiTapThucHanh613.Models
{
    public partial class LTQLDB : DbContext
    {
        public LTQLDB()
            : base("name=LTQLDB")
        {
        }
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<DangNhap> DangNhaps { get; set; }
        public virtual DbSet<XuatKho> XuatKhos { get; set; }
        public virtual DbSet<NhapKho> NhapKhos { get; set; }
        public virtual DbSet<NCC> NCCs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NVKho> NVKhos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
