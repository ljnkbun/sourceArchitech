﻿using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class RequestDivisionFile : BaseEntity
    {
        public int RequestDivisionId { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public virtual RequestDivision RequestDivision { get; set; }
    }
}
