﻿namespace Shopfloor.EventBus.Models.Responses
{
    public class GetShipmentTermByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
