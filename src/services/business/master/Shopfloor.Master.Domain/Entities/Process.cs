using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Process : BaseMasterEntity
    {
        public Process()
        {
            OperationLibraries = new List<OperationLibrary>();
            Machines = new List<Machine>();
            Lines = new List<Line>();
            PlanningGroups = new List<PlanningGroup>();
        }
        public int? WFXProcessId { get; set; }
        public string DefaultArticleOutput { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductGroupId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? SubCategoryGroupId { get; set; }
        public int? DivisionId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual SubCategoryGroup SubCategoryGroup { get; set; }
        public virtual ICollection<OperationLibrary> OperationLibraries { get; set; }
        public virtual ICollection<Machine> Machines { get; set; }
        public virtual ICollection<Line> Lines { get; set; }
        public virtual ICollection<PlanningGroup> PlanningGroups { get; set; }
        public virtual Division Division { get; set; }
    }
}