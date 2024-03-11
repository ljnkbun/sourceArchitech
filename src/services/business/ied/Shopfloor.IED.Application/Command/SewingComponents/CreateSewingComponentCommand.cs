using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingComponents
{
    public class CreateSewingComponentCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateSewingComponentCommandHandler : IRequestHandler<CreateSewingComponentCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingComponentRepository _repository;
        public CreateSewingComponentCommandHandler(IMapper mapper,
            ISewingComponentRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingComponentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingComponent>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
