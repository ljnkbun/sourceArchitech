﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class BuyerProductCategoryConfiguration : BaseConfiguration<BuyerProductCategory>
    {
        public override void Configure(EntityTypeBuilder<BuyerProductCategory> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.CategoryCode).HasMaxLength(200);
            builder.Property(e => e.CategoryName).HasMaxLength(500);

            builder.HasOne(s => s.Buyer)
                 .WithMany(g => g.ProductCategories)
                 .HasForeignKey(s => s.BuyerId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}