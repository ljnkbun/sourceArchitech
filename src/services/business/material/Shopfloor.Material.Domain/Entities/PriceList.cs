﻿using Shopfloor.Core.Models.Entities;
using Shopfloor.Material.Domain.Enums;

namespace Shopfloor.Material.Domain.Entities
{
    public class PriceList : BaseEntity
    {
        public PriceList()
        {
            PriceListDetails = new HashSet<PriceListDetail>();
        }

        public string RequestNo { get; set; }

        public string CategoryCode { get; set; }

        public string CategoryName { get; set; }

        public string SupplierCode { get; set; }

        public string SupplierName { get; set; }

        public ProcessStatus Status { get; set; }

        public Guid? ApproveUserId { get; set; }

        public string ApproveName { get; set; }

        public string ReasonReject { get; set; }

        public virtual ICollection<PriceListDetail> PriceListDetails { get; set; }
    }
}