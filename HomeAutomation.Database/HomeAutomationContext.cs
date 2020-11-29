using HomeAutomation.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace HomeAutomation.Database
{
    public class HomeAutomationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("DataSource=/home/bjarne/Documents/NET_Core/HomeAutomation/Sqlite/homeautomation.db");

        public DbSet<GatewayEntity> GatewayEntity { get; set; }
    }
}