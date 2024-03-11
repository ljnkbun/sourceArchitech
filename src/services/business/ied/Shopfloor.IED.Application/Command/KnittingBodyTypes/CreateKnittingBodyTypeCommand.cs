using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingBodyTypes
{
    public class CreateKnittingBodyTypeCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    public class CreateKnittingBodyTypeCommandHandler : IRequestHandler<CreateKnittingBodyTypeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingBodyTypeRepository _repository;
        public CreateKnittingBodyTypeCommandHandler(IMapper mapper,
            IKnittingBodyTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateKnittingBodyTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<KnittingBodyType>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
