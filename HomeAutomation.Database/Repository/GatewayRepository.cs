using System;
using System.Threading.Tasks;
using HomeAutomation.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace HomeAutomation.Database.Repository
{
    public class GatewayRepository
    {
        private readonly IDbContextFactory<HomeAutomationContext> contextFactory;

        public GatewayRepository(IDbContextFactory<HomeAutomationContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        
        public Task Save(GatewayEntity gatewayEntity)
        {
            try
            {
                using (var context = contextFactory.CreateDbContext())
                {
                    context.GatewayEntity.Add(gatewayEntity);
                    context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Task.CompletedTask;
        }
    }
}