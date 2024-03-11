using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingFeeders
{
    public class CreateKnittingFeederCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    public class CreateKnittingFeederCommandHandler : IRequestHandler<CreateKnittingFeederCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingFeederRepository _repository;
        public CreateKnittingFeederCommandHandler(IMapper mapper,
            IKnittingFeederRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateKnittingFeederCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<KnittingFeeder>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
