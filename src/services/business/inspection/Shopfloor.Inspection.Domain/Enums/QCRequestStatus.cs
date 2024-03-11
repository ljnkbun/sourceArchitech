using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopfloor.Inspection.Domain.Enums
{
    public enum QCRequestStatus : byte
    {
        Pending = 0,
        InProgress = 1,
        ByPass = 2,
        Completed = 3,
        Cancelled=4,
        Approved=5,
    }
}
