﻿using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.Lights
{
    public class LightParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
