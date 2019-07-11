namespace ToDo.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class daysToCompleteNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ToDoLists", "DaysToComplete", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ToDoLists", "DaysToComplete", c => c.Int(nullable: false));
        }
    }
}
