﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class RequestTypeConfiguration : BaseNameConfiguration<RequestType>
    {
        public override void Configure(EntityTypeBuilder<RequestType> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).HasMaxLength(500);
        }
    }
}
