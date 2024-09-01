namespace ABC_Car_Traders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Username = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                        DeletedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarMakes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Make = c.String(unicode: false),
                        CarModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarModels", t => t.CarModelId)
                .Index(t => t.CarModelId);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ModelName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CarMakeId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Color = c.String(unicode: false),
                        FuelType = c.String(unicode: false),
                        Transmission = c.String(unicode: false),
                        EngineCapacity = c.String(unicode: false),
                        BodyType = c.String(unicode: false),
                        Price = c.Int(nullable: false),
                        Image = c.String(unicode: false),
                        EngineNo = c.String(unicode: false),
                        ChassisNo = c.String(unicode: false),
                        AdditionalFeatures = c.String(unicode: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                        DeletedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarMakes", t => t.CarMakeId)
                .Index(t => t.CarMakeId);
            
            CreateTable(
                "dbo.CarSpareParts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartName = c.String(unicode: false),
                        CarMakeId = c.Int(nullable: false),
                        Description = c.String(unicode: false),
                        Category = c.String(unicode: false),
                        ImagePath = c.String(unicode: false),
                        Manufacturer = c.String(unicode: false),
                        Price = c.Int(nullable: false),
                        StockQuantity = c.Int(nullable: false),
                        WarrantyPeriod = c.String(unicode: false),
                        DateAdded = c.DateTime(nullable: false, precision: 0),
                        DateDeletedAt = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarMakes", t => t.CarMakeId)
                .Index(t => t.CarMakeId);
            
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CarId = c.Guid(),
                        SparePartId = c.Guid(),
                        UserId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                        DeletedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId)
                .ForeignKey("dbo.CarSpareParts", t => t.SparePartId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.CarId)
                .Index(t => t.SparePartId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        Phone = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                        DeletedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CarId = c.Guid(),
                        SparePartId = c.Guid(),
                        Quantity = c.Int(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Option = c.String(unicode: false),
                        WillBeDeliveredWithin = c.Int(),
                        Status = c.String(unicode: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                        DeletedDate = c.DateTime(precision: 0),
                        CarSparePart_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId)
                .ForeignKey("dbo.CarSpareParts", t => t.CarSparePart_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CarId)
                .Index(t => t.CarSparePart_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "CarSparePart_Id", "dbo.CarSpareParts");
            DropForeignKey("dbo.Orders", "CarId", "dbo.Cars");
            DropForeignKey("dbo.CartItems", "UserId", "dbo.Users");
            DropForeignKey("dbo.CartItems", "SparePartId", "dbo.CarSpareParts");
            DropForeignKey("dbo.CartItems", "CarId", "dbo.Cars");
            DropForeignKey("dbo.CarSpareParts", "CarMakeId", "dbo.CarMakes");
            DropForeignKey("dbo.Cars", "CarMakeId", "dbo.CarMakes");
            DropForeignKey("dbo.CarMakes", "CarModelId", "dbo.CarModels");
            DropIndex("dbo.Orders", new[] { "CarSparePart_Id" });
            DropIndex("dbo.Orders", new[] { "CarId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.CartItems", new[] { "UserId" });
            DropIndex("dbo.CartItems", new[] { "SparePartId" });
            DropIndex("dbo.CartItems", new[] { "CarId" });
            DropIndex("dbo.CarSpareParts", new[] { "CarMakeId" });
            DropIndex("dbo.Cars", new[] { "CarMakeId" });
            DropIndex("dbo.CarMakes", new[] { "CarModelId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.CartItems");
            DropTable("dbo.CarSpareParts");
            DropTable("dbo.Cars");
            DropTable("dbo.CarModels");
            DropTable("dbo.CarMakes");
            DropTable("dbo.Admins");
        }
    }
}
