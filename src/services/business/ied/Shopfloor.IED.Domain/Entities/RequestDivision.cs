﻿using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class RequestDivision : BaseEntity
    {
        public RequestDivision()
        {
            RequestDivisionProcesses = new HashSet<RequestDivisionProcess>();
            RequestDivisionFiles = new HashSet<RequestDivisionFile>();
        }
        public int RequestId { get; set; }
        public int DivisionId { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public int LineNumber { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string Remark { get; set; }
        public virtual Request Request { get; set; }
        public virtual ICollection<RequestDivisionFile> RequestDivisionFiles { get; set; }
        public virtual ICollection<RequestDivisionProcess> RequestDivisionProcesses { get; set; }
    }
}
