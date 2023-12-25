using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.PriceListDetails;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.PriceLists
{
    public class CreatePriceListCommand : IRequest<Response<int>>
    {
        public List<DataPriceListCreate> Data { get; set; }
    }

    public class DataPriceListCreate
    {
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

    public class CreatePriceListCommandHandler : IRequestHandler<CreatePriceListCommand, Response<int>>
    {
        private readonly IMapper _mapper;

        private readonly IPriceListRepository _repository;

        public CreatePriceListCommandHandler(IMapper mapper, ILogger<CreatePriceListCommand> logger,
            IPriceListRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePriceListCommand request,
            CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<PriceList>>(request.Data);
            await _repository.AddPriceListRangeAsync(entities);
            return new Response<int>(entities?.LastOrDefault()?.Id ?? 0);
        }
    }
}