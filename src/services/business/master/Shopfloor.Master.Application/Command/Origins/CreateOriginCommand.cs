using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Origins
{
    public class CreateOriginCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateOriginCommandHandler : IRequestHandler<CreateOriginCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IOriginRepository _repository;
        public CreateOriginCommandHandler(IMapper mapper,
            IOriginRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateOriginCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Origin>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
