using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Command.MaterialRequestFiles;
using Shopfloor.Material.Application.Command.SupplierFiles;
using Shopfloor.Material.Application.Models.SupplierProductCategory;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Suppliers
{
    public class CreateSupplierCommand : IRequest<Response<int>>
    {
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

        public ICollection<CreateSupplierFileCommand> SupplierFiles { get; set; }
    }

    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Response<int>>
    {
        private readonly IMapper _mapper;

        private readonly ISupplierRepository _repositorySupplier;

        public CreateSupplierCommandHandler(IMapper mapper, ILogger<CreateSupplierCommand> logger,
            ISupplierRepository repositoryMaterial)
        {
            _repositorySupplier = repositoryMaterial;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Supplier>(request);
            await _repositorySupplier.AddSupplierAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}