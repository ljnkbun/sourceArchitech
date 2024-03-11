using Microsoft.AspNetCore.Mvc;

using Shopfloor.Material.Application.Command.MaterialRequests;
using Shopfloor.Material.Application.Parameters.MaterialRequests;
using Shopfloor.Material.Application.Query.MaterialRequests;

namespace Shopfloor.Material.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MaterialRequestController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] MaterialRequestParameter filter)
        {
            return Ok(await Mediator.Send(new GetMaterialRequestsQuery()
            {
                RequestNo = filter.RequestNo,
                HSCode = filter.HSCode,
                ArticleCode = filter.ArticleCode,
                ArticleName = filter.ArticleName,
                ThemeCode = filter.ThemeCode,
                ThemeName = filter.ThemeName,
                ColorGroupCode = filter.ColorGroupCode,
                ColorGroupName = filter.ColorGroupName,
                PricePerCode = filter.PricePerCode,
                PricePerName = filter.PricePerName,
                BuyerCode = filter.BuyerCode,
                BuyerName = filter.BuyerName,
                SeasonCode = filter.SeasonCode,
                SeasonName = filter.SeasonName,
                BuyerRef = filter.BuyerRef,
                ProductGroupCode = filter.ProductGroupCode,
                ProductGroupName = filter.ProductGroupName,
                ProductSubCatCode = filter.ProductSubCatCode,
                ProductSubCatName = filter.ProductSubCatName,
                Status = filter.Status,
                ArticleDesc = filter.ArticleDesc,
                UomName = filter.UomName,
                UomCode = filter.UomCode,
                PicName = filter.PicName,
                ConsUomCode = filter.ConsUomCode,
                ConsUomName = filter.ConsUomName,
                StoringUomCode = filter.StoringUomCode,
                StoringUomName = filter.StoringUomName,
                SecondaryUomCode = filter.SecondaryUomCode,
                SecondaryUomName = filter.SecondaryUomName,
                SecondaryUomConversion = filter.SecondaryUomConversion,
                StockMovementUomCode = filter.StockMovementUomCode,
                StockMovementUomName = filter.StockMovementUomName,
                BuyingCurrencyCode = filter.BuyingCurrencyCode,
                BuyingCurrencyName = filter.BuyingCurrencyName,
                SupplierCode = filter.SupplierCode,
                SupplierName = filter.SupplierName,
                SupplierRef = filter.SupplierRef,
                BuyerDivisionSupplierCode = filter.BuyerDivisionSupplierCode,
                BuyerDivisionSupplierName = filter.BuyerDivisionSupplierName,
                ColorTypeCode = filter.ColorTypeCode,
                ColorTypeName = filter.ColorTypeName,
                ConstructionCode = filter.ConstructionCode,
                ConstructionName = filter.ConstructionName,
                DesignAndPattern = filter.DesignAndPattern,
                DesignAndPatternName = filter.DesignAndPatternName,
                Brand = filter.Brand,
                ContentName = filter.ContentName,
                CountCode = filter.CountCode,
                CountName = filter.CountName,
                BuyingPrice = filter.BuyingPrice,
                CropSeasonCode = filter.CropSeasonCode,
                CropSeasonName = filter.CropSeasonName,
                MaterialTypeCode = filter.MaterialTypeCode,
                MaterialTypeName = filter.MaterialTypeName,
                DivisionCode = filter.DivisionCode,
                DivisionName = filter.DivisionName,
                SizeGroupCode = filter.SizeGroupCode,
                SizeGroupName = filter.SizeGroupName,
                OurContactCode = filter.OurContactCode,
                OurContactName = filter.OurContactName,
                FiberTypeCode = filter.FiberTypeCode,
                FiberTypeName = filter.FiberTypeName,
                GenderCode = filter.GenderCode,
                GenderName = filter.GenderName,
                GradeCode = filter.GradeCode,
                GradeName = filter.GradeName,
                MicronaireCode = filter.MicronaireCode,
                MicronaireName = filter.MicronaireName,
                ProductCatCode = filter.ProductCatCode,
                ProductCatName = filter.ProductCatName,
                QualityCode = filter.QualityCode,
                QualityName = filter.QualityName,
                OriginCode = filter.OriginCode,
                OriginName = filter.OriginName,
                StapleCode = filter.StapleCode,
                StapleName = filter.StapleName,
                OrderQtyMultiple = filter.OrderQtyMultiple,
                ProvisionalStyleRef = filter.ProvisionalStyleRef,
                ApproveName = filter.ApproveName,
                ApproveUserId = filter.ApproveUserId,
                SampleRef = filter.SampleRef,
                Remarks = filter.Remarks,
                ReorderLevel = filter.ReorderLevel,
                StockMovementConversion = filter.StockMovementConversion,
                CatalogPath = filter.CatalogPath,
                InternalPrice = filter.InternalPrice,
                Finish = filter.Finish,
                MinimumOrder = filter.MinimumOrder,
                MaximumQty = filter.MaximumQty,
                MinimumOrderQty = filter.MinimumOrderQty,
                RequirementMultiple = filter.RequirementMultiple,
                Weight = filter.Weight,
                ArticleNameChinese = filter.ArticleNameChinese,
                FabricAndMaterial = filter.FabricAndMaterial,
                StrengthCode = filter.StrengthCode,
                StrengthName = filter.StrengthName,
                HSNCode = filter.HSNCode,
                HTSCode = filter.HTSCode,
                MinimumQty = filter.MinimumQty,
                PerSizeConsCode = filter.PerSizeConsCode,
                PerSizeConsName = filter.PerSizeConsName,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                CreatedFrom = filter.CreatedFrom,
                CreatedTo = filter.CreatedTo,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,
                SlidingExpiration = filter.SlidingExpiration,
                ReasonReject = filter.ReasonReject
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetMaterialRequestQuery() { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateMaterialRequestCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateMaterialRequestCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteMaterialRequestCommand { Id = id }));
        }

        [HttpPut("Approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            return Ok(await Mediator.Send(new ApproveMaterialRequestCommand { Id = id }));
        }

        [HttpPut("SendApprove/{id}")]
        public async Task<IActionResult> SendApprove(int id)
        {
            return Ok(await Mediator.Send(new SendApproveMaterialRequestCommand { Id = id }));
        }

        [HttpPut("SendExport/{id}")]
        public async Task<IActionResult> SendExport(int id)
        {
            return Ok(await Mediator.Send(new SendExportMaterialRequestCommand { Id = id }));
        }

        [HttpPut("Reject/{id}")]
        public async Task<IActionResult> Reject(int id, RejectMaterialRequestCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Import")]
        public async Task<IActionResult> Import(IFormFile file, string type)
        {
            return Ok(await Mediator.Send(new ImportMaterialRequestCommand { File = file, Type = type }));
        }

        [HttpGet("ExportExcel")]
        public async Task<IActionResult> ExportExcel([FromQuery] ExportMaterialRequestParameter model)
        {
            return await Mediator.Send(new ExportMaterialRequestQuery { Ids = model.Ids, Type = model.Type });
        }
    }
}