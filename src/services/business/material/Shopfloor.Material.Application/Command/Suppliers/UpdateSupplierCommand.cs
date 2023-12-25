using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.SupplierProductCategory;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Suppliers
{
    public class UpdateSupplierCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Address { get; set; }

        public string BillAddress { get; set; }

        public string ShipAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string CategoryCode { get; set; }

        public string CategoryName { get; set; }

        public string Telephone { get; set; }

        public string CurrencyCode { get; set; }

        public string CurrencyName { get; set; }

        public string ContactFirstName { get; set; }

        public string ContactLastName { get; set; }

        public string Email { get; set; }

        public decimal Tolearancen { get; set; }

        public string PaymentTerms { get; set; }

        public string DeliveryTerms { get; set; }

        public string ShipmentTerms { get; set; }

        public string CountryOfOrigin { get; set; }

        public string PortOfLoading { get; set; }

        public string GroupNameCode { get; set; }

        public string GroupName { get; set; }

        public string CatalogPath { get; set; }

        public string AccountGroupCode { get; set; }

        public string AccountGroupName { get; set; }

        public string BankAccountNumber { get; set; }

        public string BankAddressDetails { get; set; }

        public string VATNumber { get; set; }

        public string CompanyWebsite { get; set; }

        public string Remakes { get; set; }

        public string PicName { get; set; }

        public ProcessStatus Status { get; set; }

        public string CompanyId { get; set; }

        public string Pan { get; set; }

        public string Tin { get; set; }

        public string CustomHouse { get; set; }

        public string SupplierTypeCode { get; set; }

        public string SupplierTypeName { get; set; }

        public Guid? ApproveUserId { get; set; }

        public string ApproveName { get; set; }

        #region BusinessSegment

        public bool IsRetailer { get; set; }

        public bool IsWholesaler { get; set; }

        public bool IsManufacture { get; set; }

        public bool IsTransporter { get; set; }

        public bool IsBuying { get; set; }

        public bool IsServiceProvider { get; set; }

        public bool IsBrand { get; set; }

        public bool IsComposition { get; set; }

        public bool IsOther { get; set; }

        public string SegmentOther { get; set; }

        #endregion BusinessSegment

        public string SwiftCode { get; set; }

        public decimal MaximumOutAmount { get; set; }

        public ICollection<SupplierProductCategoryModel> SupplierProductCategories { get; set; }
    }

    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Response<int>>
    {
        private readonly ISupplierRepository _repository;

        private readonly ILogger<UpdateSupplierCommand> _logger;

        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(ISupplierRepository repository, ILogger<UpdateSupplierCommand> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateSupplierCommand command, CancellationToken cancellationToken)
        {
            var entity =
                await _repository.GetWithIncludeByIdAsync(command.Id);
            if (entity == null)
                throw new ApiException($"Supplier Not Found.");
            var dataSupplier = _mapper.Map<Supplier>(command);
            entity.PicName = dataSupplier.PicName;
            entity.BillAddress = dataSupplier.BillAddress;
            entity.BankAddressDetails = dataSupplier.BankAddressDetails;
            entity.Address = dataSupplier.Address;
            entity.CountryOfOrigin = dataSupplier.CountryOfOrigin;
            entity.City = dataSupplier.City;
            entity.PortOfLoading = dataSupplier.PortOfLoading;
            entity.State = dataSupplier.State;
            entity.ZipCode = dataSupplier.ZipCode;
            entity.AccountGroupCode = dataSupplier.AccountGroupCode;
            entity.AccountGroupName = dataSupplier.AccountGroupName;
            entity.BankAccountNumber = dataSupplier.BankAccountNumber;
            entity.CatalogPath = dataSupplier.CatalogPath;
            entity.CurrencyCode = dataSupplier.CurrencyCode;
            entity.CurrencyName = dataSupplier.CurrencyName;
            entity.CompanyWebsite = dataSupplier.CompanyWebsite;
            entity.ContactFirstName = dataSupplier.ContactFirstName;
            entity.ContactLastName = dataSupplier.ContactLastName;
            entity.DeliveryTerms = dataSupplier.DeliveryTerms;
            entity.Email = dataSupplier.Email;
            entity.PaymentTerms = dataSupplier.PaymentTerms;
            entity.GroupName = dataSupplier.GroupName;
            entity.Remakes = dataSupplier.Remakes;
            entity.ShipmentTerms = dataSupplier.ShipmentTerms;
            entity.Name = dataSupplier.Name;
            entity.Address = dataSupplier.Address;
            entity.ShipAddress = dataSupplier.ShipAddress;
            entity.ShortName = dataSupplier.ShortName;
            entity.BillAddress = dataSupplier.BillAddress;
            entity.Telephone = dataSupplier.Telephone;
            entity.VATNumber = dataSupplier.VATNumber;
            entity.ZipCode = dataSupplier.ZipCode;
            entity.CountryCode = dataSupplier.CountryCode;
            entity.CountryName = dataSupplier.CountryName;
            entity.CompanyId = dataSupplier.CompanyId;
            entity.CustomHouse = dataSupplier.CustomHouse;
            entity.Pan = dataSupplier.Pan;
            entity.Tin = dataSupplier.Tin;
            entity.SupplierTypeCode = dataSupplier.SupplierTypeCode;
            entity.SupplierTypeName = dataSupplier.SupplierTypeName;
            entity.IsRetailer = dataSupplier.IsRetailer;
            entity.IsWholesaler = dataSupplier.IsWholesaler;
            entity.IsManufacture = dataSupplier.IsManufacture;
            entity.IsTransporter = dataSupplier.IsTransporter;
            entity.IsBuying = dataSupplier.IsBuying;
            entity.IsServiceProvider = dataSupplier.IsServiceProvider;
            entity.IsBrand = dataSupplier.IsBrand;
            entity.IsComposition = dataSupplier.IsComposition;
            entity.IsOther = dataSupplier.IsOther;
            entity.SegmentOther = dataSupplier.SegmentOther;
            entity.SwiftCode = dataSupplier.SwiftCode;
            entity.MaximumOutAmount = dataSupplier.MaximumOutAmount;
            entity.CategoryCode = dataSupplier.CategoryCode;
            entity.CategoryName = dataSupplier.CategoryName;

            #region Product Category

            // lay ra Entities can add them
            var addEntitiesProductCategory =
                dataSupplier.SupplierProductCategories.Where(x => x.Id == 0).ToList();

            // lấy ra Entities cần update
            var updateEntitiesProductCategory =
                dataSupplier.SupplierProductCategories.Where(x => x.Id != 0).ToList();
            var deleteEntitiesProductCategory =
                entity.SupplierProductCategories
                    .Where(x => !updateEntitiesProductCategory.Any() || updateEntitiesProductCategory.Any(y => y.Id != x.Id))
                    .ToList();

            #endregion Product Category

            entity.SupplierProductCategories = updateEntitiesProductCategory;
            await _repository.UpdateSupplierAsync(entity, new BaseListCreateDeleteEntity<SupplierProductCategory>
            {
                LstDataAdd = addEntitiesProductCategory,
                LstDataDelete = deleteEntitiesProductCategory
            });

            return new Response<int>(command.Id);
        }
    }
}