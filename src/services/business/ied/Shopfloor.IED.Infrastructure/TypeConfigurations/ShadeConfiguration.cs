﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class ShadeConfiguration : BaseConfiguration<Shade>
    {
        public override void Configure(EntityTypeBuilder<Shade> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).HasMaxLength(500);
        }
    }
}
