using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class PlanningGroupFactoryConfiguration : BaseConfiguration<PlanningGroupFactory>
    {
        public override void Configure(EntityTypeBuilder<PlanningGroupFactory> builder)
        {
            base.Configure(builder);
            builder.HasOne(e => e.PlanningGroup)
                .WithMany(e => e.PlanningGroupFactories)
                .HasForeignKey(e => e.PlanningGroupId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Factory)
                .WithMany(e => e.PlanningGroupFactories)
                .HasForeignKey(e => e.FactoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
