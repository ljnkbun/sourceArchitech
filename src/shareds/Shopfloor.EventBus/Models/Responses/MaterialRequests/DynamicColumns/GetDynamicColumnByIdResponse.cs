using Shopfloor.EventBus.Definations;

namespace Shopfloor.EventBus.Models.Responses.MaterialRequests.DynamicColumns
{
    public class GetDynamicColumnByIdResponse : BaseResponse
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public FieldType FieldType { get; set; }

        public bool IsContent { get; set; }

        public bool IsRequired { get; set; }

        public string CategoryCode { get; set; }

        public int DisplayIndex { get; set; }
    }
}
