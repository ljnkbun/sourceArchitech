using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Command.ProductGroupUOMs;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.UOMs
{
    public class CreateUOMCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int DecimalPlaces { get; set; }
        public int OrderDecimalPlaces { get; set; }
        public string Action { get; set; }
        public ICollection<CreateProductGroupUOMCommand> ProductGroupUOMs { get; set; }
    }

    public class CreateUOMCommandHandler : IRequestHandler<CreateUOMCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUOMRepository _repository;

        public CreateUOMCommandHandler(IMapper mapper,
            IUOMRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateUOMCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UOM>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}