﻿namespace Shopfloor.EventBus.Models.Requests
{
    public class GetMachineTypesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
