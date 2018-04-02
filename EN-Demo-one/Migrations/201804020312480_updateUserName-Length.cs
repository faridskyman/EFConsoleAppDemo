namespace EN_Demo_one.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUserNameLength : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 64));
            AddPrimaryKey("dbo.Users", "Username");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "Username");
        }
    }
}
