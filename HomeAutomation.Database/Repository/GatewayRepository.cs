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
        
        public async Task SaveOrUpdate(GatewayEntity gatewayEntity)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                GatewayEntity entity = await context.GatewayEntity.SingleOrDefaultAsync(c => c.Id == gatewayEntity.Id);
                if (entity == null)
                {
                    context.GatewayEntity.Add(gatewayEntity);
                }
                else
                {
                    context.GatewayEntity.Attach(gatewayEntity);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}