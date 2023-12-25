using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CountTypes
{
    public class CreateCountTypeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateCountTypeCommandHandler : IRequestHandler<CreateCountTypeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICountTypeRepository _repository;
        public CreateCountTypeCommandHandler(IMapper mapper,
            ICountTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCountTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CountType>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
