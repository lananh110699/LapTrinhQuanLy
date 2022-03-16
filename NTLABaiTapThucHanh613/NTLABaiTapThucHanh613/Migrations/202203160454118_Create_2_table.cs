namespace NTLABaiTapThucHanh613.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_2_table : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Đăng Nhập", newName: "DangNhap");
            RenameTable(name: "dbo.Hàng Hóa", newName: "HangHoa");
            RenameTable(name: "dbo.Nhà Cung Cấp", newName: "NCC");
            RenameTable(name: "dbo.Nhập Kho", newName: "NhapKho");
            RenameTable(name: "dbo.Xuất Kho", newName: "XuatKho");
            CreateTable(
                "dbo.Khach Hang",
                c => new
                    {
                        MaKhachHang = c.String(nullable: false, maxLength: 128),
                        TenKhachHang = c.String(),
                        SĐT = c.Int(nullable: false),
                        DiaChi = c.String(),
                    })
                .PrimaryKey(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.Nhan Vien Kho",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 128),
                        TenNV = c.String(),
                        SĐT = c.Int(nullable: false),
                        DiaChi = c.String(),
                        STK = c.String(),
                        NganHang = c.String(),
                    })
                .PrimaryKey(t => t.MaNV);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nhan Vien Kho");
            DropTable("dbo.Khach Hang");
            RenameTable(name: "dbo.XuatKho", newName: "Xuất Kho");
            RenameTable(name: "dbo.NhapKho", newName: "Nhập Kho");
            RenameTable(name: "dbo.NCC", newName: "Nhà Cung Cấp");
            RenameTable(name: "dbo.HangHoa", newName: "Hàng Hóa");
            RenameTable(name: "dbo.DangNhap", newName: "Đăng Nhập");
        }
    }
}
