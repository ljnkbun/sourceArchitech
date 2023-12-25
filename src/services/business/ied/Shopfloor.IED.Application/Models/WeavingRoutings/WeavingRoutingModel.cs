﻿using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.WeavingRoutings
{
    public class WeavingRoutingModel : BaseModel
    {
        public int WeavingIEDId { get; set; }
        public int LineNumber { get; set; }
        public string WeavingProcess { get; set; }
        public string WeavingOperation { get; set; }
        public string MachineType { get; set; }
        public bool Deleted { get; set; }
    }
}
