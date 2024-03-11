using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactoryDetails
{
    public class CreateStripFactoryDetailCommand : IRequest<Response<int>>
    {
        public int PorDetailId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public PorType? TypePORDetail { get; set; }
        public int StripFactoryId { get; set; }
    }

    public class CreateStripFactoryDetailCommandHandler : IRequestHandler<CreateStripFactoryDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStripFactoryRepository _factoryRepository;
        private readonly IStripFactoryDetailRepository _repository;

        public CreateStripFactoryDetailCommandHandler(IMapper mapper
            , IStripFactoryDetailRepository repository
            , IStripFactoryRepository factoryRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _factoryRepository = factoryRepository;
        }

        public async Task<Response<int>> Handle(CreateStripFactoryDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StripFactoryDetail>(command);
            var result = await _repository.AddAsync(entity);
            return new Response<int>(result.Id);
        }
    }
}
