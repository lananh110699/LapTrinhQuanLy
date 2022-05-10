namespace NTLABaiTapThucHanh613.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DangNhap",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        RoleID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.HangHoa",
                c => new
                    {
                        MaHang = c.String(nullable: false, maxLength: 128),
                        TenHang = c.String(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaHang);
            
            CreateTable(
                "dbo.NhapKho",
                c => new
                    {
                        MaPhieuNhap = c.String(nullable: false, maxLength: 128),
                        NgayNhap = c.String(nullable: false),
                        MaNCC = c.String(nullable: false, maxLength: 128),
                        MaHang = c.String(nullable: false, maxLength: 128),
                        TenHang = c.String(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                        ThanhTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhieuNhap)
                .ForeignKey("dbo.HangHoa", t => t.MaHang, cascadeDelete: true)
                .ForeignKey("dbo.NCC", t => t.MaNCC, cascadeDelete: true)
                .Index(t => t.MaNCC)
                .Index(t => t.MaHang);
            
            CreateTable(
                "dbo.NCC",
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
                "dbo.XuatKho",
                c => new
                    {
                        MaPhieuXuat = c.String(nullable: false, maxLength: 128),
                        NgayXuat = c.String(nullable: false),
                        MaKhachHang = c.String(nullable: false, maxLength: 128),
                        MaHang = c.String(nullable: false, maxLength: 128),
                        TenHang = c.String(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                        ThanhTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhieuXuat)
                .ForeignKey("dbo.HangHoa", t => t.MaHang, cascadeDelete: true)
                .ForeignKey("dbo.Khach Hang", t => t.MaKhachHang, cascadeDelete: true)
                .Index(t => t.MaKhachHang)
                .Index(t => t.MaHang);
            
            CreateTable(
                "dbo.Khach Hang",
                c => new
                    {
                        MaKhachHang = c.String(nullable: false, maxLength: 128),
                        TenKhachHang = c.String(nullable: false),
                        SĐT = c.Int(nullable: false),
                        DiaChi = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.Nhan Vien Kho",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 128),
                        TenNV = c.String(nullable: false),
                        SĐT = c.Int(nullable: false),
                        DiaChi = c.String(nullable: false),
                        STK = c.String(nullable: false),
                        NganHang = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaNV);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.XuatKho", "MaKhachHang", "dbo.Khach Hang");
            DropForeignKey("dbo.XuatKho", "MaHang", "dbo.HangHoa");
            DropForeignKey("dbo.NhapKho", "MaNCC", "dbo.NCC");
            DropForeignKey("dbo.NhapKho", "MaHang", "dbo.HangHoa");
            DropIndex("dbo.XuatKho", new[] { "MaHang" });
            DropIndex("dbo.XuatKho", new[] { "MaKhachHang" });
            DropIndex("dbo.NhapKho", new[] { "MaHang" });
            DropIndex("dbo.NhapKho", new[] { "MaNCC" });
            DropTable("dbo.Roles");
            DropTable("dbo.Nhan Vien Kho");
            DropTable("dbo.Khach Hang");
            DropTable("dbo.XuatKho");
            DropTable("dbo.NCC");
            DropTable("dbo.NhapKho");
            DropTable("dbo.HangHoa");
            DropTable("dbo.DangNhap");
        }
    }
}
