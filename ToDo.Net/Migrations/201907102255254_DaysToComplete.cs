namespace ToDo.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DaysToComplete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoLists", "DaysToComplete", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoLists", "DaysToComplete");
        }
    }
}
