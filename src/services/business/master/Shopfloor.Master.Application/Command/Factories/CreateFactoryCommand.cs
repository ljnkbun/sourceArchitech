using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Factories
{
    public class CreateFactoryCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? DivisionId { get; set; }

    }
    public class CreateFactoryCommandHandler : IRequestHandler<CreateFactoryCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFactoryRepository _repository;
        public CreateFactoryCommandHandler(IMapper mapper,
            IFactoryRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFactoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Factory>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
