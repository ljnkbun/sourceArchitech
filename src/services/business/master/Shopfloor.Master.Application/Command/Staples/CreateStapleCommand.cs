using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Staples
{
    public class CreateStapleCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateStapleCommandHandler : IRequestHandler<CreateStapleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStapleRepository _repository;
        public CreateStapleCommandHandler(IMapper mapper,
            IStapleRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateStapleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Staple>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
