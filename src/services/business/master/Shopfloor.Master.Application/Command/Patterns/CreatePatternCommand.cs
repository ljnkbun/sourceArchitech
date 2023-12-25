using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Patterns
{
    public class CreatePatternCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreatePatternCommandHandler : IRequestHandler<CreatePatternCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPatternRepository _repository;
        public CreatePatternCommandHandler(IMapper mapper,
            IPatternRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePatternCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Pattern>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
