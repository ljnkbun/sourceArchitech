using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class ProcessConfiguration : BaseMasterConfiguration<Process>
    {
        public override void Configure(EntityTypeBuilder<Process> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.DefaultArticleOutput).HasMaxLength(250);
            builder.HasOne(e => e.Category)
                .WithMany(e => e.Processs)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(e => e.Division)
                .WithMany(e => e.Processes)
                .HasForeignKey(e => e.DivisionId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(e => e.ProductGroup)
                .WithMany(e => e.Processs)
                .HasForeignKey(e => e.ProductGroupId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(e => e.SubCategory)
                .WithMany(e => e.Processs)
                .HasForeignKey(e => e.SubCategoryId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(e => e.SubCategoryGroup)
                .WithMany(e => e.Processs)
                .HasForeignKey(e => e.SubCategoryGroupId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}