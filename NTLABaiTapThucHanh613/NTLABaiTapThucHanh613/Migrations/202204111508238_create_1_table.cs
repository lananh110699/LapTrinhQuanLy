namespace NTLABaiTapThucHanh613.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_1_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhapKho", "MaNCC", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.XuatKho", "MaKhachHang", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Khach Hang", "TenKhachHang", c => c.String(nullable: false));
            AlterColumn("dbo.Khach Hang", "DiaChi", c => c.String(nullable: false));
            AlterColumn("dbo.NhapKho", "MaHang", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Nhan Vien Kho", "TenNV", c => c.String(nullable: false));
            AlterColumn("dbo.Nhan Vien Kho", "DiaChi", c => c.String(nullable: false));
            AlterColumn("dbo.Nhan Vien Kho", "STK", c => c.String(nullable: false));
            AlterColumn("dbo.Nhan Vien Kho", "NganHang", c => c.String(nullable: false));
            AlterColumn("dbo.XuatKho", "MaHang", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.NhapKho", "MaNCC");
            CreateIndex("dbo.NhapKho", "MaHang");
            CreateIndex("dbo.XuatKho", "MaKhachHang");
            CreateIndex("dbo.XuatKho", "MaHang");
            AddForeignKey("dbo.NhapKho", "MaHang", "dbo.HangHoa", "MaHang", cascadeDelete: true);
            AddForeignKey("dbo.NhapKho", "MaNCC", "dbo.NCC", "MaNCC", cascadeDelete: true);
            AddForeignKey("dbo.XuatKho", "MaHang", "dbo.HangHoa", "MaHang", cascadeDelete: true);
            AddForeignKey("dbo.XuatKho", "MaKhachHang", "dbo.Khach Hang", "MaKhachHang", cascadeDelete: true);
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
            AlterColumn("dbo.XuatKho", "MaHang", c => c.String(nullable: false));
            AlterColumn("dbo.Nhan Vien Kho", "NganHang", c => c.String());
            AlterColumn("dbo.Nhan Vien Kho", "STK", c => c.String());
            AlterColumn("dbo.Nhan Vien Kho", "DiaChi", c => c.String());
            AlterColumn("dbo.Nhan Vien Kho", "TenNV", c => c.String());
            AlterColumn("dbo.NhapKho", "MaHang", c => c.String(nullable: false));
            AlterColumn("dbo.Khach Hang", "DiaChi", c => c.String());
            AlterColumn("dbo.Khach Hang", "TenKhachHang", c => c.String());
            DropColumn("dbo.XuatKho", "MaKhachHang");
            DropColumn("dbo.NhapKho", "MaNCC");
        }
    }
}
