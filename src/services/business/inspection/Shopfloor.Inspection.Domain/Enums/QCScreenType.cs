using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopfloor.Inspection.Domain.Enums
{
    public enum QCScreenType : byte 
    {
        Garment =1,
        Fabric4Point=2,
        Fabric100Point=3,
        TCStandardFixed=4,
        TCStandardPercent = 5
    }
}
