using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.GroupNames
{
    public class CreateGroupNameCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateGroupNameCommandHandler : IRequestHandler<CreateGroupNameCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IGroupNameRepository _repository;
        public CreateGroupNameCommandHandler(IMapper mapper,
            IGroupNameRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateGroupNameCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<GroupName>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
