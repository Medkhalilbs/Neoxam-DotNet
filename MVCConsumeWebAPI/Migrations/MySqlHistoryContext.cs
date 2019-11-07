using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;


namespace MVCConsumeWebAPI.Migrations //you can put any namespace here, but be sure you will put the corret using statement in the next file. Just create a new class :D
{
    public class MySqlHistoryContext : HistoryContext
{

    public MySqlHistoryContext(DbConnection connection, string defaultSchema) : base(connection, defaultSchema)
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(200).IsRequired();
    }
}
}