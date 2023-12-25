using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Twists
{
    public class CreateTwistCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateTwistCommandHandler : IRequestHandler<CreateTwistCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ITwistRepository _repository;
        public CreateTwistCommandHandler(IMapper mapper,
            ITwistRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTwistCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Twist>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
