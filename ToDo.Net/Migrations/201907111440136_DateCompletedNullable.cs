namespace ToDo.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateCompletedNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ToDoLists", "DateCompleted", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ToDoLists", "DateCompleted", c => c.DateTime(nullable: false));
        }
    }
}
