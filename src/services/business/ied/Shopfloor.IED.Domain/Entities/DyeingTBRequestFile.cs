﻿using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class DyeingTBRequestFile : BaseEntity
    {
        public int DyeingTBRequestId { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }

        public virtual DyeingTBRequest DyeingTBRequest { get; set; }
    }
}