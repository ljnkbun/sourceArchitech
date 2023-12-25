using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Counts
{
    public class CreateCountCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateCountCommandHandler : IRequestHandler<CreateCountCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICountRepository _repository;
        public CreateCountCommandHandler(IMapper mapper,
            ICountRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCountCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Count>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
