﻿using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.CountTypes
{
    public class CountTypeParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
