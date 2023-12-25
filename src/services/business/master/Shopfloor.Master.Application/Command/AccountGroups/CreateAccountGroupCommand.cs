using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.AccountGroups
{
    public class CreateAccountGroupCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateAccountGroupCommandHandler : IRequestHandler<CreateAccountGroupCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IAccountGroupRepository _repository;
        public CreateAccountGroupCommandHandler(IMapper mapper,
            IAccountGroupRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAccountGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<AccountGroup>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
