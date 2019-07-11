namespace ToDo.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredAttribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ToDoLists", "Task", c => c.String(nullable: false));
            AlterColumn("dbo.ToDoLists", "TaskPriority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ToDoLists", "TaskPriority", c => c.Int());
            AlterColumn("dbo.ToDoLists", "Task", c => c.String());
        }
    }
}
