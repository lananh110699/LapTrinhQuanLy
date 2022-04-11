namespace NTLABaiTapThucHanh613.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_account : DbMigration
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
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
            DropTable("dbo.DangNhap");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DangNhap",
                c => new
                    {
                        TenDangNhap = c.String(nullable: false, maxLength: 50),
                        MatKhau = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TenDangNhap);
            
            DropTable("dbo.Roles");
            DropTable("dbo.DangNhap");
        }
    }
}
