using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.PORDetails
{
    public class CreatePORDetailCommand : IRequest<Response<int>>
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal OrderedQuantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public string Remarks { get; set; }
        public int PORId { get; set; }
        public PORStatus? Status { get; set; }
    }
    public class CreatePORDetailCommandHandler : IRequestHandler<CreatePORDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPORDetailRepository _repository;
        public CreatePORDetailCommandHandler(IMapper mapper
            , IPORDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(CreatePORDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PORDetail>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
