namespace EN_Demo_one.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUserDisplayName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "DisplayName", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "DisplayName", c => c.String());
        }
    }
}
