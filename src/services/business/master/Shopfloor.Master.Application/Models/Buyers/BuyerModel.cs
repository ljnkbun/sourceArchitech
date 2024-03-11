using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.Buyers
{
    public class BuyerModel : BaseModel
    {
        public string WFXBuyerId { get; set; }

        public string Name { get; set; }
    }
}
