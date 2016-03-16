namespace PremierMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        PersonneID = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 50),
                        Courriel = c.String(maxLength: 100),
                        DateNaissance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersonneID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personnes");
        }
    }
}
