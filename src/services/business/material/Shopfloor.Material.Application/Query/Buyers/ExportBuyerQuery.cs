using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shopfloor.Core.Helpers;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.Buyers
{
    public class ExportBuyerQuery : IRequest<FileContentResult>
    {
        public int[] Ids { get; set; }
    }

    public class ExportBuyerQueryHandler : IRequestHandler<ExportBuyerQuery, FileContentResult>
    {
        private readonly IBuyerRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExportBuyerQueryHandler(
            IBuyerRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<FileContentResult> Handle(ExportBuyerQuery request, CancellationToken cancellationToken)
        {
            if (request.Ids == null || request.Ids.Length == 0)
                throw new ArgumentNullException(nameof(request.Ids));
            var buyers = await _repository.GetBuyerByIdsAsync(request.Ids);
            var data = buyers.Select(CellData).ToList();
            if (data.Count == 0)
                throw new Exception("Not found data");
            var fname = "BuyerMaster.xls";
            var fullPath = Path.Combine(_webHostEnvironment.ContentRootPath, "TemplateWFX", fname);
            if (!File.Exists(fullPath))
                throw new FileNotFoundException(fname);
            var ms = ExportExcelHelper.WriteExcelHSSF(fullPath, new ExcelInputDataModel
            {
                Data = data,
                RowIndex = 1,
                SheetIndex = 0
            });
            return new FileContentResult(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = fname,
                EnableRangeProcessing = true,
            };
        }

        private Dictionary<string, object> CellData(Buyer buyer)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("A", buyer.Name);
            dic.Add("B", buyer.Code);
            dic.Add("C", buyer.ShortName);
            dic.Add("D", buyer.Address);
            dic.Add("E", buyer.Address2);
            dic.Add("F", buyer.Address3);
            dic.Add("G", buyer.BillAddress);
            dic.Add("H", buyer.ShipAddress);
            dic.Add("I", buyer.City);
            dic.Add("J", buyer.State);
            dic.Add("K", buyer.ZipCode);
            dic.Add("L", buyer.CountryName);
            dic.Add("M", buyer.Telephone);
            dic.Add("N", buyer.CurrencyName);
            dic.Add("O", buyer.BuyerTypeName);
            dic.Add("P", buyer.ContactFirstName);
            dic.Add("Q", buyer.ContactLastName);
            dic.Add("R", buyer.ContactEmail);
            var businessSegments = new List<string>();
            if (buyer.IsRetailer)
                businessSegments.Add("Retailer");
            if (buyer.IsWholesaler)
                businessSegments.Add("Wholesaler");
            if (buyer.IsManufacture)
                businessSegments.Add("Manufacturer");
            if (buyer.IsTransporter)
                businessSegments.Add("Transporter");
            if (buyer.IsBuying)
                businessSegments.Add("Buying Agent/Office");
            if (buyer.IsServiceProvider)
                businessSegments.Add("Service Provider");
            if (buyer.IsBrand)
                businessSegments.Add("Brand");
            if (buyer.IsComposition)
                businessSegments.Add("Composition Dealer");
            if (buyer.IsOther)
            {
                businessSegments.Add("Other (Please specify)");
                businessSegments.Add(buyer.SegmentOther);
            }
            dic.Add("S", string.Join(',', businessSegments));
            dic.Add("T", string.Join(',', buyer.ProductCategories?.Select(x => x.CategoryCode)));
            dic.Add("U", buyer.Tolearance);
            dic.Add("V", buyer.PaymentTerms);
            dic.Add("W", buyer.DeliveryTerms);
            dic.Add("X", buyer.ShipmentTerms);
            dic.Add("Y", buyer.FinalDestination);
            dic.Add("Z", buyer.CountryOfFinalDestination);
            dic.Add("AA", buyer.PortofDischarge);
            dic.Add("AB", buyer.GroupName);
            dic.Add("AC", buyer.Category);
            dic.Add("AD", buyer.PAN);
            dic.Add("AE", buyer.TIN);
            dic.Add("AF", buyer.AccountGroupName);
            dic.Add("AG", buyer.Market);
            dic.Add("AH", buyer.CustomHouse);
            dic.Add("AI", buyer.VATNumber);
            dic.Add("AJ", buyer.BankAccountNumber);
            dic.Add("AK", buyer.BankAddress);
            dic.Add("AL", buyer.SwiftCode);
            dic.Add("AM", buyer.MaximumOutAmount);
            return dic;
        }
    }
}