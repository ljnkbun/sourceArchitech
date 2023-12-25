using Microsoft.AspNetCore.Mvc;

using Shopfloor.Core.Models.Parameters;
using Shopfloor.Material.Application.Command.Buyers;
using Shopfloor.Material.Application.Parameters.Buyers;
using Shopfloor.Material.Application.Query.Buyers;

namespace Shopfloor.Material.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BuyerController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BuyerParameter filter)
        {
            return Ok(await Mediator.Send(new GetBuyersQuery()
            {
                Code = filter.Code,
                Name = filter.Name,
                ShortName = filter.ShortName,
                Address = filter.Address,
                City = filter.City,
                State = filter.State,
                ZipCode = filter.ZipCode,
                Country = filter.Country,
                CountryName = filter.CountryName,
                Telephone = filter.Telephone,
                Currency = filter.Currency,
                CurrencyName = filter.CurrencyName,
                ContactFirstName = filter.ContactFirstName,
                ContactLastName = filter.ContactLastName,
                ContactEmail = filter.ContactEmail,
                Tolearance = filter.Tolearance,
                BuyerType = filter.BuyerType,
                BuyerTypeName = filter.BuyerTypeName,
                AccountGroup = filter.AccountGroup,
                AccountGroupName = filter.AccountGroupName,
                BankAccountNumber = filter.BankAccountNumber,
                BankAddress = filter.BankAddress,
                VATNumber = filter.VATNumber,
                MaximumOutAmount = filter.MaximumOutAmount,
                Status = filter.Status,
                RequestNo = filter.RequestNo,
                SwiftCode = filter.SwiftCode,
                Department = filter.Department,
                ApproveUserId = filter.ApproveUserId,
                ApproveName = filter.ApproveName,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                Deleted = filter.Deleted,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ReasonReject = filter.ReasonReject,
                ModifiedUserId = filter.ModifiedUserId,
                CreatedFrom = filter.CreatedFrom,
                CreatedTo = filter.CreatedTo,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration,
                IsBrand = filter.IsBrand,
                IsBuying = filter.IsBuying,
                IsComposition = filter.IsComposition,
                IsManufacture = filter.IsManufacture,
                IsOther = filter.IsOther,
                IsRetailer = filter.IsRetailer,
                IsServiceProvider = filter.IsServiceProvider,
                IsTransporter = filter.IsTransporter,
                IsWholesaler = filter.IsWholesaler,
                SegmentOther = filter.SegmentOther,
                Address2 = filter.Address2,
                Address3 = filter.Address3,
                BillAddress = filter.BillAddress,
                Category = filter.Category,
                CountryOfFinalDestination = filter.CountryOfFinalDestination,
                CustomHouse = filter.CustomHouse,
                DeliveryTerms = filter.DeliveryTerms,
                FinalDestination = filter.FinalDestination,
                GroupName = filter.GroupName,
                GroupNameCode = filter.GroupNameCode,
                Market = filter.Market,
                PAN = filter.PAN,
                ShipAddress = filter.ShipAddress,
                PaymentTerms = filter.PaymentTerms,
                PortofDischarge = filter.PortofDischarge,
                ShipmentTerms = filter.ShipmentTerms,
                TIN = filter.TIN,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetBuyerQuery() { Id = id }));
        }

        [HttpGet("GetByCode/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            return Ok(await Mediator.Send(new GetBuyerByCodeQuery() { Code = code }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBuyerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateBuyerCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("SendApprove/{id}")]
        public async Task<IActionResult> SendApprove(int id)
        {
            return Ok(await Mediator.Send(new SendApproveBuyerCommand { Id = id }));
        }

        [HttpPut("Approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            return Ok(await Mediator.Send(new ApproveBuyerCommand { Id = id }));
        }

        [HttpPut("Reject/{id}")]
        public async Task<IActionResult> Reject(int id, RejectBuyerCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new SoftDeleteBuyerCommand { Id = id }));
        }

        [HttpPost("Import")]
        public async Task<IActionResult> Import(IFormFile file)
        {
            return Ok(await Mediator.Send(new ImportBuyerCommand { File = file }));
        }

        [HttpGet("CodeName")]
        public async Task<IActionResult> GetCodeName([FromQuery] RequestParameter filter)
        {
            return Ok(await Mediator.Send(new GetCodeNameBuyersQuery
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,
            }));
        }

        [HttpGet("ExportExcel")]
        public async Task<IActionResult> ExportExcel([FromQuery] ExportBuyerParameter model)
        {
            return await Mediator.Send(new ExportBuyerQuery { Ids = model.Ids });
        }
    }
}