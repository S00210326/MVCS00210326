namespace Business.DomainClasses.S00210326.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        InceptionDate = c.DateTime(nullable: false, storeType: "date"),
                        CustomerID = c.Int(nullable: false),
                        CurrentBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Conditions = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionType = c.Int(nullable: false),
                        Ammount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionDate = c.DateTime(nullable: false, storeType: "date"),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "AccountID" });
            DropIndex("dbo.Accounts", new[] { "CustomerID" });
            DropTable("dbo.Transactions");
            DropTable("dbo.AccountTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.Accounts");
        }
    }
}
