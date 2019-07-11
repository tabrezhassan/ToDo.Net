namespace ToDo.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompletedColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoLists", "Completed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoLists", "Completed");
        }
    }
}
