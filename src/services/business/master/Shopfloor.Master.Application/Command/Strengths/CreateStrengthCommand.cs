using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Strengths
{
    public class CreateStrengthCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateStrengthCommandHandler : IRequestHandler<CreateStrengthCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStrengthRepository _repository;
        public CreateStrengthCommandHandler(IMapper mapper,
            IStrengthRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateStrengthCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Strength>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
