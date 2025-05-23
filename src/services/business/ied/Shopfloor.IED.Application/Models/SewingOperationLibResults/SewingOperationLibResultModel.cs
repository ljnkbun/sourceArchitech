﻿using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.SewingOperationLibResults
{
    public class SewingOperationLibResultModel
    {
        public TMUType TMUType { get; set; }
        public decimal TMU { get; set; }
        public decimal BasicMunite { get; set; }
        public decimal PersonalAllowance { get; set; }
        public decimal? MachineDelay { get; set; }
        public decimal Total { get; set; }
        public decimal Contingency { get; set; }
        public decimal SMV { get; set; }
        public decimal Cost { get; set; }
        public bool Deleted { get; set; }
    }
}
