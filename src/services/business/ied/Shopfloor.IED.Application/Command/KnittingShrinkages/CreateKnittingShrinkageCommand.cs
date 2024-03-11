using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingShrinkages
{
    public class CreateKnittingShrinkageCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    public class CreateKnittingShrinkageCommandHandler : IRequestHandler<CreateKnittingShrinkageCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingShrinkageRepository _repository;
        public CreateKnittingShrinkageCommandHandler(IMapper mapper,
            IKnittingShrinkageRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateKnittingShrinkageCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<KnittingShrinkage>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
