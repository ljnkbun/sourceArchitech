using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class SupplierConfiguration : BaseConfiguration<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.RequestNo).HasColumnType("varchar(50)");

            builder.Property(e => e.AccountGroupCode).HasColumnType("varchar(200)");

            builder.Property(e => e.AccountGroupName).HasMaxLength(200);

            builder.Property(e => e.BankAccountNumber).HasColumnType("varchar(100)");

            builder.Property(e => e.BankAddressDetails).HasMaxLength(500);

            builder.Property(e => e.CatalogPath).HasMaxLength(500);

            builder.Property(e => e.City).HasMaxLength(100);

            builder.Property(e => e.CountryCode).HasColumnType("varchar(100)");

            builder.Property(e => e.CountryName).HasMaxLength(200);

            builder.Property(e => e.CurrencyCode).HasColumnType("varchar(100)");

            builder.Property(e => e.CurrencyName).HasMaxLength(200);

            builder.Property(e => e.CompanyWebsite).HasMaxLength(500);

            builder.Property(e => e.ContactFirstName).HasMaxLength(500);

            builder.Property(e => e.ContactLastName).HasMaxLength(500);

            builder.Property(e => e.CountryOfOrigin).HasMaxLength(500);

            builder.Property(e => e.DeliveryTerms).HasColumnType("varchar(100)");

            builder.Property(e => e.Email).HasColumnType("varchar(250)");

            builder.Property(e => e.GroupNameCode).HasColumnType("varchar(100)");

            builder.Property(e => e.GroupName).HasMaxLength(500);

            builder.Property(e => e.PaymentTerms).HasColumnType("varchar(100)");

            builder.Property(e => e.PortOfLoading).HasMaxLength(500);

            builder.Property(e => e.ShipmentTerms).HasColumnType("varchar(100)");

            builder.Property(e => e.Name).HasMaxLength(500);

            builder.Property(e => e.State).HasMaxLength(200);

            builder.Property(e => e.Address).HasMaxLength(500);

            builder.Property(e => e.BillAddress).HasMaxLength(500);

            builder.Property(e => e.ShipAddress).HasMaxLength(500);

            builder.Property(e => e.Tolearancen).HasColumnType("decimal(28,8)");

            builder.Property(e => e.ShortName).HasMaxLength(200);

            builder.Property(e => e.VATNumber).HasMaxLength(20);

            builder.Property(e => e.Telephone).HasColumnType("varchar(100)");

            builder.Property(e => e.ZipCode).HasColumnType("varchar(30)");

            builder.Property(e => e.PicName).HasMaxLength(500);

            builder.Property(e => e.CompanyId).HasColumnType("varchar(200)");

            builder.Property(e => e.Pan).HasMaxLength(200);

            builder.Property(e => e.Tin).HasMaxLength(200);

            builder.Property(e => e.AccountGroupName).HasMaxLength(200);
            builder.Property(e => e.AccountGroupCode).HasColumnType("varchar(100)");

            builder.Property(e => e.CustomHouse).HasMaxLength(500);
            builder.Property(e => e.SupplierTypeCode).HasColumnType("varchar(100)");
            builder.Property(e => e.SupplierTypeName).HasMaxLength(500);
            builder.Property(e => e.CategoryCode).HasColumnType("varchar(100)");
            builder.Property(e => e.CategoryName).HasMaxLength(500);
            builder.Property(e => e.SwiftCode).HasColumnType("varchar(100)");
            builder.Property(e => e.MaximumOutAmount).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ApproveName).HasMaxLength(500);
            builder.Property(e => e.SegmentOther).HasMaxLength(500);
        }
    }
}