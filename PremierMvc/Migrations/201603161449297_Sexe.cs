namespace PremierMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sexe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personnes", "Sexe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personnes", "Sexe");
        }
    }
}
