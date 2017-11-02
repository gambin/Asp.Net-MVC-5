namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCollums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SignupFee", c => c.Short(nullable: false));
            AddColumn("dbo.MembershipTypes", "DiscountRates", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "SingnupFee");
            DropColumn("dbo.MembershipTypes", "DiscountRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "DiscountRate", c => c.Byte(nullable: false));
            AddColumn("dbo.MembershipTypes", "SingnupFee", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "DiscountRates");
            DropColumn("dbo.MembershipTypes", "SignupFee");
        }
    }
}
