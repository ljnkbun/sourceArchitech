using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Application.Models.MaterialRequests
{
    public class MaterialDynamicColumnModel : BaseModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Value { get; set; }
    }
}
