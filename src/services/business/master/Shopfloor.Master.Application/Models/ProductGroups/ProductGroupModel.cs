﻿using Shopfloor.Core.Models.Entities;
using Shopfloor.Master.Application.Models.MaterialTypeMapProductGroups;

namespace Shopfloor.Master.Application.Models.ProductGroups
{
    public class ProductGroupModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public ICollection<MapProductGroupToMaterialTypeModel> MaterialTypeMapProductGroups { get; set; }
    }
}
