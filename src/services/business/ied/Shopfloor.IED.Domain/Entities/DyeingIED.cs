using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class DyeingIED : DivisionIED
    {
        public DyeingIED()
        {
            DyeingRoutings = new HashSet<DyeingRouting>();
            DyeingFiles = new HashSet<DyeingFile>();
        }

        public int? RequestTypeId { get; set; }

        public string Color { get; set; }

        public string ColorRef { get; set; }

        public int? RecipeId { get; set; }
        public string TCFNo { get; set; }
        public int? WFXInputMaterialId { get; set; }
        public string InputMaterialName { get; set; }
        public virtual Recipe Recipe { get; set; }

        public virtual RequestType RequestType { get; set; }

        public virtual RequestArticleOutput RequestArticleOutput { get; set; }

        public virtual ICollection<DyeingRouting> DyeingRoutings { get; set; }
        public virtual ICollection<DyeingFile> DyeingFiles { get; set; }
    }
}