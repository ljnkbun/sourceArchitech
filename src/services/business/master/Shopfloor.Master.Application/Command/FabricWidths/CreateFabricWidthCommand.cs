using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.FabricWidths
{
    public class CreateFabricWidthCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string Inseam { get; set; }
    }
    public class CreateFabricWidthCommandHandler : IRequestHandler<CreateFabricWidthCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFabricWidthRepository _repository;
        public CreateFabricWidthCommandHandler(IMapper mapper,
            IFabricWidthRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFabricWidthCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<FabricWidth>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
