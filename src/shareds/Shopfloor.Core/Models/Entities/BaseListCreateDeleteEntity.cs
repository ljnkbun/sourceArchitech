using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopfloor.Core.Models.Entities
{
    public class BaseListCreateDeleteEntity<T>
    {
        public List<T> LstDataDelete { get; set; }
        public List<T> LstDataAdd { get; set; }
    }
}
