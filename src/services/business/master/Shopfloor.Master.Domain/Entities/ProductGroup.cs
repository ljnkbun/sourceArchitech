﻿using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class ProductGroup : BaseMasterEntity
    {
        public ProductGroup()
        {
            SubCategories = new HashSet<SubCategory>();
            MaterialTypeMapProductGroups = new HashSet<MaterialTypeMapProductGroup>();
            Processs = new HashSet<Process>();
            ProductGroupUOMs = new HashSet<ProductGroupUOM>();
        }

        public ProductGroup(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<MaterialTypeMapProductGroup> MaterialTypeMapProductGroups { get; set; }
        public virtual ICollection<Process> Processs { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
        public virtual ICollection<ProductGroupUOM> ProductGroupUOMs { get; set; }
    }
}