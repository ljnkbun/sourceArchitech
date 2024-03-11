using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingBorderStyles
{
    public class CreateWeavingBorderStyleCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    public class CreateWeavingBorderStyleCommandHandler : IRequestHandler<CreateWeavingBorderStyleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingBorderStyleRepository _repository;
        public CreateWeavingBorderStyleCommandHandler(IMapper mapper,
            IWeavingBorderStyleRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingBorderStyleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingBorderStyle>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
