using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingBackgroundStyles
{
    public class CreateWeavingBackgroundStyleCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    public class CreateWeavingBackgroundStyleCommandHandler : IRequestHandler<CreateWeavingBackgroundStyleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingBackgroundStyleRepository _repository;
        public CreateWeavingBackgroundStyleCommandHandler(IMapper mapper,
            IWeavingBackgroundStyleRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingBackgroundStyleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingBackgroundStyle>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
