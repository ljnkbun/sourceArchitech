using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Shades
{
    public class CreateShadeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateShadeCommandHandler : IRequestHandler<CreateShadeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IShadeRepository _repository;
        public CreateShadeCommandHandler(IMapper mapper,
            IShadeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateShadeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Shade>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
