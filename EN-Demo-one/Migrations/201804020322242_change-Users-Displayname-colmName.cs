namespace EN_Demo_one.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeUsersDisplaynamecolmName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "DisplayName", newName: "display_name");
            AlterColumn("dbo.Users", "display_name", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "display_name", c => c.String(maxLength: 256));
            RenameColumn(table: "dbo.Users", name: "display_name", newName: "DisplayName");
        }
    }
}
