namespace NTLABaiTapThucHanh613.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class done : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Đăng Nhập",
                c => new
                    {
                        TenDangNhap = c.String(nullable: false, maxLength: 50),
                        MatKhau = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TenDangNhap);
            
            CreateTable(
                "dbo.Hàng Hóa",
                c => new
                    {
                        MaHang = c.String(nullable: false, maxLength: 128),
                        TenHang = c.String(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaHang);
            
            CreateTable(
                "dbo.Nhà Cung Cấp",
                c => new
                    {
                        MaNCC = c.String(nullable: false, maxLength: 128),
                        TenNCC = c.String(nullable: false),
                        TenHang = c.String(nullable: false),
                        DiaChi = c.String(),
                        SDT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaNCC);
            
            CreateTable(
                "dbo.Nhập Kho",
                c => new
                    {
                        MaPhieuNhap = c.String(nullable: false, maxLength: 128),
                        NgayNhap = c.String(nullable: false),
                        MaHang = c.String(nullable: false),
                        TenHang = c.String(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                        ThanhTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhieuNhap);
            
            CreateTable(
                "dbo.Xuất Kho",
                c => new
                    {
                        MaPhieuXuat = c.String(nullable: false, maxLength: 128),
                        NgayXuat = c.String(nullable: false),
                        MaHang = c.String(nullable: false),
                        TenHang = c.String(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                        ThanhTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhieuXuat);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Xuất Kho");
            DropTable("dbo.Nhập Kho");
            DropTable("dbo.Nhà Cung Cấp");
            DropTable("dbo.Hàng Hóa");
            DropTable("dbo.Đăng Nhập");
        }
    }
}
