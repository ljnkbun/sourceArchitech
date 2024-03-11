using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingComponentGroups
{
    public class CreateSewingComponentGroupCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateSewingComponentGroupCommandHandler : IRequestHandler<CreateSewingComponentGroupCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingComponentGroupRepository _repository;
        public CreateSewingComponentGroupCommandHandler(IMapper mapper,
            ISewingComponentGroupRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingComponentGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingComponentGroup>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
