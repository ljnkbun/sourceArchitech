using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.Buyers;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Buyers
{
    public class UpdateBuyerCommand : IRequest<Response<int>>
    {
        #region Properties

        public string Code { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string BillAddress { get; set; }

        public string ShipAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string CountryName { get; set; }

        public string Telephone { get; set; }

        public string Currency { get; set; }

        public string CurrencyName { get; set; }

        public string BuyerType { get; set; }

        public string BuyerTypeName { get; set; }

        public string ContactFirstName { get; set; }

        public string ContactLastName { get; set; }

        public string ContactEmail { get; set; }

        public decimal? Tolearance { get; set; }

        public string PaymentTerms { get; set; }

        public string DeliveryTerms { get; set; }

        public string ShipmentTerms { get; set; }

        public string FinalDestination { get; set; }

        public string CountryOfFinalDestination { get; set; }

        public string PortofDischarge { get; set; }

        public string GroupNameCode { get; set; }

        public string GroupName { get; set; }

        public string AccountGroup { get; set; }

        public string AccountGroupName { get; set; }

        public string Category { get; set; }

        public string PAN { get; set; }

        public string TIN { get; set; }

        public string Market { get; set; }

        public string CustomHouse { get; set; }

        public string BankAccountNumber { get; set; }

        public string BankAddress { get; set; }

        public string VATNumber { get; set; }

        public string SwiftCode { get; set; }

        public string Department { get; set; }

        public decimal MaximumOutAmount { get; set; }

        #endregion Properties

        #region Process

        public ProcessStatus Status { get; set; }

        public string ApproveUserId { get; set; }

        public string ApproveName { get; set; }

        #endregion Process

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

        #region List

        public ICollection<BuyerProductCategoryModel> ProductCategories { get; set; }

        #endregion List

        #region Base properties

        public int Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? CreatedUserId { get; set; }

        public Guid? ModifiedUserId { get; set; }

        #endregion Base properties
    }

    public class UpdateBuyerCommandHandler : IRequestHandler<UpdateBuyerCommand, Response<int>>
    {
        private readonly IBuyerRepository _repositoryBuyer;

        private readonly IBuyerProductCategoryRepository _buyerProductCategoryRepository;

        public UpdateBuyerCommandHandler(IBuyerRepository repositoryBuyer, IBuyerProductCategoryRepository buyerProductCategoryRepository)
        {
            _repositoryBuyer = repositoryBuyer;
            _buyerProductCategoryRepository = buyerProductCategoryRepository;
        }

        public async Task<Response<int>> Handle(UpdateBuyerCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repositoryBuyer.GetByIdAsync(command.Id);
            if (entity == null)
                throw new ApiException($"{nameof(Buyer)} Not Found.");
            var ignores = new string[]
            {
                nameof(Buyer.Status),
                nameof(Buyer.Id),
                nameof(Buyer.CreatedDate),
                nameof(Buyer.CreatedUserId),
                nameof(Buyer.ProductCategories),
            };
            command.ModifiedDate = DateTime.Now;
            command.TransferProperties(entity, ignores);

            var deletedCategories = await _buyerProductCategoryRepository.GetListAsync(x => x.BuyerId == command.Id);                                                                                                           // || !command.ProductCategories.Any(v => v.Id == x.Id)).ToList();
            var insertCategories = command.ProductCategories?.Select(x => new BuyerProductCategory
            {
                BuyerId = command.Id,
                CategoryCode = x.CategoryCode,
                CategoryName = x.CategoryName,
                IsActive = x.IsActive,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                ModifiedUserId = x.ModifiedUserId,
                CreatedUserId = x.CreatedUserId
            }).ToList();
            await _repositoryBuyer.UpdateBuyerAsync(entity, insertCategories, deletedCategories);
            return new Response<int>(command.Id);
        }
    }
}