using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.DyeingIEDs
{
    public class SearchDyeingIEDParameter : RequestParameter
    {
        public Status? Status { get; set; }

        public string RequestNo { get; set; }

        public string RequestType { get; set; }

        public string ArticleName { get; set; }

        public string ProductGroup { get; set; }

        public string SubCategory { get; set; }

        public string Buyer { get; set; }

        public DateTime? ExpectedDate { get; set; }

        public string Creator { get; set; }

        public string Department { get; set; }

        public string RecipeNo { get; set; }
    }
}