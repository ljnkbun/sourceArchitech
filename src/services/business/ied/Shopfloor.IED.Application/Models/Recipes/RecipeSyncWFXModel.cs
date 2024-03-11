using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopfloor.IED.Application.Models.Recipes
{
    public class RecipeSyncWFXModel
    {
        public RecipeSyncWFXHeaderModel header { get; set; }
        public List<RecipeSyncWFXFlexFieldModel> flexfield { get; set; }
        public List<RecipeSyncWFXMaterialModel> Materials { get; set; }
        public RecipeSyncWFXWaterdetailModel waterdetail { get; set; }
    }
    public class RecipeSyncWFXFlexFieldModel
    {
        public string flexfieldname { get; set; }
        public string flexfieldvalue { get; set; }
    }

    public class RecipeSyncWFXMaterialDetailModel
    {
        public int? material_id { get; set; }
        public string consumptiontypecode { get; set; }
        public decimal consumption { get; set; }
        public decimal ratio { get; set; }
        public int ph { get; set; }
        public string supplier_code { get; set; }
        public string rate { get; set; }
    }

    public class RecipeSyncWFXMaterialModel
    {
        public int? process_id { get; set; }
        public string operation_id { get; set; }
        public string suboperation_id { get; set; }
        public string machinesubcategory_id { get; set; }
        public decimal temperature { get; set; }
        public decimal timevalue { get; set; }
        public string timeunit { get; set; }
        public List<RecipeSyncWFXMaterialDetailModel> materialdetail { get; set; }
    }

    public class RecipeSyncWFXHeaderModel
    {
        public string recipecode { get; set; }
        public string recipegroup_id { get; set; }
        public string recipedescription { get; set; }
        public string validityfromdate { get; set; }
        public string validitytodate { get; set; }
        public string color { get; set; }
        public string shade { get; set; }
        public int recipecategory_id { get; set; }
        public string light1_id { get; set; }
        public string light2_id { get; set; }
        public string incharge { get; set; }
        public int sampleweight { get; set; }
        public string uom { get; set; }
        public int liquorratio { get; set; }
        public string totalvolume { get; set; }
        public int pickupperc { get; set; }
        public string remarks { get; set; }
    }

    public class RecipeSyncWFXWaterdetailModel
    {
        public string wateruom { get; set; }
        public string waterrate { get; set; }
    }
}
