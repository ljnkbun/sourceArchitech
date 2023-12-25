using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class ArticleSyncConfigConfiguration : BaseConfiguration<ArticleSyncConfig>
    {
        public override void Configure(EntityTypeBuilder<ArticleSyncConfig> builder)
        {
            base.Configure(builder);
        }
    }
}
