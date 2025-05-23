﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class BuyerConfiguration : BaseMasterConfiguration<Buyer>
    {
        public override void Configure(EntityTypeBuilder<Buyer> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.RequestNo).HasColumnType("varchar(50)");
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.ShortName).HasMaxLength(200);
            builder.Property(e => e.Address).HasMaxLength(1000);
            builder.Property(e => e.Address2).HasMaxLength(1000);
            builder.Property(e => e.Address3).HasMaxLength(1000);
            builder.Property(e => e.City).HasMaxLength(100);
            builder.Property(e => e.State).HasMaxLength(200);
            builder.Property(e => e.ZipCode).HasMaxLength(30);
            builder.Property(e => e.Country).HasMaxLength(50);
            builder.Property(e => e.CountryName).HasMaxLength(100);
            builder.Property(e => e.Telephone).HasMaxLength(100);
            builder.Property(e => e.Currency).HasMaxLength(50);
            builder.Property(e => e.CurrencyName).HasMaxLength(100);
            builder.Property(e => e.ContactFirstName).HasMaxLength(200);
            builder.Property(e => e.ContactLastName).HasMaxLength(200);
            builder.Property(e => e.ContactEmail).HasMaxLength(250);
            builder.Property(e => e.Tolearance).HasMaxLength(10);
            builder.Property(e => e.AccountGroup).HasMaxLength(200);
            builder.Property(e => e.AccountGroupName).HasMaxLength(200);
            builder.Property(e => e.BankAccountNumber).HasMaxLength(100);
            builder.Property(e => e.BankAddress).HasMaxLength(500);
            builder.Property(e => e.DeliveryTerms).HasMaxLength(250);
            builder.Property(e => e.PaymentTerms).HasMaxLength(250);
            builder.Property(e => e.ShipmentTerms).HasMaxLength(250);
            builder.Property(e => e.PAN).HasMaxLength(100);
            builder.Property(e => e.TIN).HasMaxLength(100);
            builder.Property(e => e.Market).HasMaxLength(500);
            builder.Property(e => e.CustomHouse).HasMaxLength(500);
            builder.Property(e => e.VATNumber).HasMaxLength(20);
            builder.Property(e => e.BillAddress).HasMaxLength(1000);
            builder.Property(e => e.ShipAddress).HasMaxLength(1000);
            builder.Property(e => e.BuyerType).HasMaxLength(100);
            builder.Property(e => e.BuyerTypeName).HasMaxLength(500);
            builder.Property(e => e.FinalDestination).HasMaxLength(500);
            builder.Property(e => e.CountryOfFinalDestination).HasMaxLength(500);
            builder.Property(e => e.PortofDischarge).HasMaxLength(500);
            builder.Property(e => e.GroupNameCode).HasMaxLength(100);
            builder.Property(e => e.GroupName).HasMaxLength(500);
            builder.Property(e => e.Category).HasMaxLength(500);
            builder.Property(e => e.SwiftCode).HasMaxLength(500);
            builder.Property(e => e.Department).HasMaxLength(500);
            builder.Property(e => e.ApproveUserId).HasMaxLength(500);
            builder.Property(e => e.ApproveName).HasMaxLength(500);
            builder.Property(e => e.SegmentOther).HasMaxLength(500);
            builder.Property(e => e.Status).HasColumnType("tinyint");
            builder.Property(e => e.MaximumOutAmount).HasColumnType("decimal(28,8)");
        }
    }
}