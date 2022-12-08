namespace HostServer.Persistance.Logs
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogEntries",
                c => new
                    {
                        LogEntryId = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        DateTimeUtc = c.DateTime(nullable: false),
                        Thread = c.String(),
                        Level = c.String(),
                        Logger = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.LogEntryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogEntries");
        }
    }
}
