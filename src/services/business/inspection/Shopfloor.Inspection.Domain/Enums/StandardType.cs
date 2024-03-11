using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopfloor.Inspection.Domain.Enums
{
    public enum StandardType : byte
    {
        Percentage = 1,
        Fixed = 2,
        AQL= 3,
        OneHundredPointSystem=4,
        FourPointSystem=5
    }
}
