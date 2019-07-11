namespace ToDo.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateCompleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoLists", "DateCompleted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoLists", "DateCompleted");
        }
    }
}
