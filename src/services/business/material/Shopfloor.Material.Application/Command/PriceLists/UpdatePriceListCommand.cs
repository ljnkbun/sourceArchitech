using AutoMapper;

using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.PriceListDetails;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.PriceLists
{
    public class UpdatePriceListCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public string CategoryCode { get; set; }

        public string CategoryName { get; set; }

        public string SupplierCode { get; set; }

        public string SupplierName { get; set; }

        public ProcessStatus Status { get; set; }

        public Guid? ApproveUserId { get; set; }

        public string ApproveName { get; set; }

        public string ReasonReject { get; set; }

        public ICollection<PriceListDetailModel> PriceListDetails { get; set; }
    }

    public class UpdatePriceListCommandHandler : IRequestHandler<UpdatePriceListCommand, Response<int>>
    {
        private readonly IPriceListRepository _repositoryPriceList;

        private readonly IPriceListDetailRepository _repositoryPriceListDetail;

        private readonly IMapper _mapper;

        public UpdatePriceListCommandHandler(IPriceListRepository repositoryMaterial,
            IMapper mapper, IPriceListDetailRepository repositoryPriceListDetail)
        {
            _repositoryPriceList = repositoryMaterial;
            _mapper = mapper;
            _repositoryPriceListDetail = repositoryPriceListDetail;
        }

        public async Task<Response<int>> Handle(UpdatePriceListCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repositoryPriceList.GetByIdAsync(command.Id);
            if (entity == null)
                throw new ApiException($"PriceList Not Found.");
            var ignores = new string[]
            {
                nameof(PriceList.Status),
                nameof(PriceList.Id),
                nameof(PriceList.CreatedDate),
                nameof(PriceList.CreatedUserId),
                nameof(PriceList.PriceListDetails),
            };
            command.TransferProperties(entity, ignores);
            entity.ModifiedDate = DateTime.Now;

            var deleteEntitiesPriceListDetails = await _repositoryPriceListDetail.GetPriceListDetailByParentIdAsync(command.Id);

            var insertEntitiesPriceListDetails = _mapper.Map<List<PriceListDetail>>(command.PriceListDetails);

            await _repositoryPriceList.UpdatePriceListAsync(entity, new BaseListCreateDeleteEntity<PriceListDetail>
            {
                LstDataAdd = insertEntitiesPriceListDetails,
                LstDataDelete = deleteEntitiesPriceListDetails
            });

            return new Response<int>(command.Id);
        }
    }
}