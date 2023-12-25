using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.FabricContents
{
    public class CreateFabricContentCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateFabricContentCommandHandler : IRequestHandler<CreateFabricContentCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFabricContentRepository _repository;
        public CreateFabricContentCommandHandler(IMapper mapper,
            IFabricContentRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFabricContentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<FabricContent>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
