using AutoMapper;
using MediatR;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Command.CapacityColors
{
    public class CreateCapacityColorCommand : IRequest<Response<int>>
    {
        public string Color { get; set; }
		public decimal? FromRange { get; set; }
		public decimal? ToRange { get; set; }
    }
    public class CreateCapacityColorCommandHandler : IRequestHandler<CreateCapacityColorCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICapacityColorRepository _repository;
        public CreateCapacityColorCommandHandler(IMapper mapper,
            ICapacityColorRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCapacityColorCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CapacityColor>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
