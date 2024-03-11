using Shopfloor.EventBus.Definations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopfloor.EventBus.Models.Dtos
{
    public class QCDefectDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? ParrentId { get; set; }
        public string Name { get; set; }
        public string NameEN { get; set; }
        public int? DivisonId { get; set; }
        public string DivisonName { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessName { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public InspectionType InspectionType { get; set; }
        public int Level { get; set; }
    }
}
