namespace EntityFrameworkSqliteCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 2147483647),
                        PersonId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persons", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId, name: "IX_Orders_PersonId");
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Persons", "RoleId", c => c.Long());
            CreateIndex("dbo.Persons", "RoleId", name: "IX_Persons_RoleId");
            AddForeignKey("dbo.Persons", "RoleId", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "PersonId", "dbo.Persons");
            DropForeignKey("dbo.Persons", "RoleId", "dbo.Roles");
            DropIndex("dbo.Persons", "IX_Persons_RoleId");
            DropIndex("dbo.Orders", "IX_Orders_PersonId");
            DropColumn("dbo.Persons", "RoleId");
            DropTable("dbo.Roles");
            DropTable("dbo.Orders");
        }
    }
}
