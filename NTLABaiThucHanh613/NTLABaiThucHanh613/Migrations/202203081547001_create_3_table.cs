namespace NTLABaiThucHanh613.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_3_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.String(nullable: false, maxLength: 128),
                        EmployeeName = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonID = c.String(nullable: false, maxLength: 128),
                        PersonName = c.String(),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudnetID = c.String(nullable: false, maxLength: 128),
                        StudnetName = c.String(),
                    })
                .PrimaryKey(t => t.StudnetID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
            DropTable("dbo.Person");
            DropTable("dbo.Employee");
        }
    }
}
