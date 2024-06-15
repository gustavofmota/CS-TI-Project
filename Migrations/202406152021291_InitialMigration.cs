namespace TI_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Budgets");
            DropTable("dbo.Expenses");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.RecurringExpenses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RecurringExpenses",
                c => new
                    {
                        RecurringExpenseId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        Description = c.String(),
                        Frequency = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.RecurringExpenseId);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseId);
            
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        BudgetId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BudgetId);
            
        }
    }
}
