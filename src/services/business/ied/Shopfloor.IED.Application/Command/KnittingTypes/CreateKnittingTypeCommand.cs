using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingTypes
{
    public class CreateKnittingTypeCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    public class CreateKnittingTypeCommandHandler : IRequestHandler<CreateKnittingTypeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingTypeRepository _repository;
        public CreateKnittingTypeCommandHandler(IMapper mapper,
            IKnittingTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateKnittingTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<KnittingType>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
