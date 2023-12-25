using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingBackgrounStyles
{
    public class CreateWeavingBackgrounStyleCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateWeavingBackgrounStyleCommandHandler : IRequestHandler<CreateWeavingBackgrounStyleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingBackgrounStyleRepository _repository;
        public CreateWeavingBackgrounStyleCommandHandler(IMapper mapper,
            IWeavingBackgrounStyleRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingBackgrounStyleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingBackgrounStyle>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
