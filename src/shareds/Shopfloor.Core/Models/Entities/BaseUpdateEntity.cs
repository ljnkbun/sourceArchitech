using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopfloor.Core.Models.Entities
{
    public class BaseUpdateEntity<T>
    {
        public IEnumerable<T> LstDataDelete { get; set; }
        public IEnumerable<T> LstDataAdd { get; set; }
        public IEnumerable<T> LstDataUpdate { get; set; }
    }
}
