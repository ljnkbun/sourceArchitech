﻿namespace Shopfloor.EventBus.Models.Requests
{
    public class GetMicronairesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
