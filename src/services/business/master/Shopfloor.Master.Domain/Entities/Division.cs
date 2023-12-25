﻿using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Division : BaseMasterEntity
    {
        public Division()
        {
            Departments = new HashSet<Department>();
            Factories = new HashSet<Factory>();
        }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Factory> Factories { get; set; }
    }
}
