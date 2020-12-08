using HomeAutomation.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HomeAutomation.Database
{
    public class HomeAutomationContext : DbContext
    {

        public DbSet<GatewayEntity> GatewayEntity { get; set; }
    }
}