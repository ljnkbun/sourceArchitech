using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shopfloor.Core.Helpers;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.Suppliers
{
    public class ExportSupplierQuery : IRequest<FileContentResult>
    {
        public int[] Ids { get; set; }
    }

    public class ExportSupplierQueryHandler : IRequestHandler<ExportSupplierQuery, FileContentResult>
    {
        private readonly ISupplierRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExportSupplierQueryHandler(
            ISupplierRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<FileContentResult> Handle(ExportSupplierQuery request, CancellationToken cancellationToken)
        {
            if (request.Ids == null || request.Ids.Length == 0)
                throw new ArgumentNullException(nameof(request.Ids));
            var data = new List<Dictionary<string, object>>();
            var suppliers = await _repository.GetSupplierByIdsAsync(request.Ids);
            foreach (var supplier in suppliers)
                data.Add(CellData(supplier));

            if (data.Count == 0)
                throw new Exception("Not found data");
            var fname = "SupplierMaster.xls";
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

        private Dictionary<string, object> CellData(Supplier supplier)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("A", supplier.CompanyId);
            dic.Add("B", supplier.Name);
            dic.Add("C", supplier.ShortName);
            dic.Add("D", supplier.Address);
            dic.Add("E", supplier.BillAddress);
            dic.Add("F", supplier.ShipAddress);
            dic.Add("G", supplier.City);
            dic.Add("H", supplier.State);
            dic.Add("I", supplier.ZipCode);
            dic.Add("J", supplier.CountryName);
            dic.Add("K", supplier.Telephone);
            dic.Add("L", supplier.CurrencyName);
            dic.Add("M", supplier.ContactFirstName);
            dic.Add("N", supplier.ContactLastName);
            dic.Add("O", supplier.Email);
            var businessSegments = new List<string>();
            if (supplier.IsRetailer)
                businessSegments.Add("Retailer");
            if (supplier.IsWholesaler)
                businessSegments.Add("Wholesaler");
            if (supplier.IsManufacture)
                businessSegments.Add("Manufacturer");
            if (supplier.IsTransporter)
                businessSegments.Add("Transporter");
            if (supplier.IsBuying)
                businessSegments.Add("Buying Agent/Office");
            if (supplier.IsServiceProvider)
                businessSegments.Add("Service Provider");
            if (supplier.IsBrand)
                businessSegments.Add("Brand");
            if (supplier.IsComposition)
                businessSegments.Add("Composition Dealer");
            if (supplier.IsOther)
            {
                businessSegments.Add("Other (Please specify)");
                businessSegments.Add(supplier.SegmentOther);
            }
            dic.Add("P", string.Join(',', businessSegments));
            dic.Add("Q", string.Join(',', supplier.SupplierProductCategories?.Select(x => x.Code)));
            dic.Add("R", supplier.Tolearancen);
            dic.Add("S", supplier.PaymentTerms);
            dic.Add("T", supplier.DeliveryTerms);
            dic.Add("U", supplier.ShipmentTerms);
            dic.Add("V", supplier.CountryOfOrigin);
            dic.Add("W", supplier.PortOfLoading);
            dic.Add("X", supplier.GroupName);
            dic.Add("Y", supplier.CategoryName);
            dic.Add("Z", supplier.Pan);
            dic.Add("AA", supplier.Tin);
            dic.Add("AB", supplier.AccountGroupName);
            dic.Add("AC", supplier.CustomHouse);
            dic.Add("AD", supplier.VATNumber);
            dic.Add("AE", supplier.SupplierTypeName);
            dic.Add("AF", supplier.BankAccountNumber);
            dic.Add("AG", supplier.BankAddressDetails);
            dic.Add("AH", supplier.SwiftCode);
            dic.Add("AI", supplier.MaximumOutAmount);
            return dic;
        }
    }
}