namespace EntityFrameworkSqliteCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Persons", "Age", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Persons", "Age");
        }
    }
}
