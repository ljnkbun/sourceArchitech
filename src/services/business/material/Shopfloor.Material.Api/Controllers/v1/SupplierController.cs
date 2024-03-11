using Microsoft.AspNetCore.Mvc;

using Shopfloor.Material.Application.Command.Suppliers;
using Shopfloor.Material.Application.Parameters.Suppliers;
using Shopfloor.Material.Application.Query.Suppliers;

namespace Shopfloor.Material.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SupplierController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SupplierParameter filter)
        {
            return Ok(await Mediator.Send(new GetSuppliersQuery
            {
                RequestNo = filter.RequestNo,
                Name = filter.Name,
                CompanyId = filter.CompanyId,
                ZipCode = filter.ZipCode,
                Address = filter.Address,
                SupplierTypeCode = filter.SupplierTypeCode,
                SupplierTypeName = filter.SupplierTypeName,
                PaymentTerms = filter.PaymentTerms,
                AccountGroupCode = filter.AccountGroupCode,
                AccountGroupName = filter.AccountGroupName,
                CurrencyCode = filter.CurrencyCode,
                CurrencyName = filter.CurrencyName,
                DeliveryTerms = filter.DeliveryTerms,
                ShipmentTerms = filter.ShipmentTerms,
                Tolearancen = filter.Tolearancen,
                Remakes = filter.Remakes,
                PicName = filter.PicName,
                ApproveUserId = filter.ApproveUserId,
                ApproveName = filter.ApproveName,
                MaximumOutAmount = filter.MaximumOutAmount,
                IsRetailer = filter.IsRetailer,
                IsWholesaler = filter.IsWholesaler,
                IsManufacture = filter.IsManufacture,
                IsTransporter = filter.IsTransporter,
                IsBuying = filter.IsBuying,
                IsServiceProvider = filter.IsServiceProvider,
                IsBrand = filter.IsBrand,
                IsComposition = filter.IsComposition,
                IsOther = filter.IsOther,
                GroupName = filter.GroupName,
                GroupNameCode = filter.GroupNameCode,
                CountryCode = filter.CountryCode,
                CountryName = filter.CountryName,
                BankAccountNumber = filter.BankAccountNumber,
                BankAddressDetails = filter.BankAddressDetails,
                BillAddress = filter.BillAddress,
                CatalogPath = filter.CatalogPath,
                City = filter.City,
                CompanyWebsite = filter.CompanyWebsite,
                ContactFirstName = filter.ContactFirstName,
                ContactLastName = filter.ContactLastName,
                CountryOfOrigin = filter.CountryOfOrigin,
                CustomHouse = filter.CustomHouse,
                Email = filter.Email,
                Pan = filter.Pan,
                Tin = filter.Tin,
                VATNumber = filter.VATNumber,
                PortOfLoading = filter.PortOfLoading,
                CategoryCode = filter.CategoryCode,
                CategoryName = filter.CategoryName,
                SegmentOther = filter.SegmentOther,
                ShipAddress = filter.ShipAddress,
                ShortName = filter.ShortName,
                SwiftCode = filter.SwiftCode,
                State = filter.State,
                Status = filter.Status,
                Telephone = filter.Telephone,
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
                Reason = filter.ReasonReject
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSupplierQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSupplierCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPut("SendExport/{id}")]
        public async Task<IActionResult> SendExport(int id)
        {
            return Ok(await Mediator.Send(new SendExportSupplierCommand { Id = id }));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSupplierCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSupplierCommand { Id = id }));
        }

        [HttpPut("Approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            return Ok(await Mediator.Send(new ApproveSupplierCommand { Id = id }));
        }

        [HttpPut("SendApprove/{id}")]
        public async Task<IActionResult> SendApprove(int id)
        {
            return Ok(await Mediator.Send(new SendApproveSupplierCommand { Id = id }));
        }

        [HttpPut("Reject/{id}")]
        public async Task<IActionResult> Reject(int id, RejectSupplierCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Import")]
        public async Task<IActionResult> Import(IFormFile file)
        {
            return Ok(await Mediator.Send(new ImportSupplierCommand { File = file }));
        }

        [HttpGet("ExportExcel")]
        public async Task<IActionResult> ExportExcel([FromQuery] ExportSupplierParameter model)
        {
            return await Mediator.Send(new ExportSupplierQuery { Ids = model.Ids });
        }
    }
}