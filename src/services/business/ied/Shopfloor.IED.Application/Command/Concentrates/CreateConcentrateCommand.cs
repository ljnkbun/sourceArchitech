using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Concentrates
{
    public class CreateConcentrateCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateConcentrateCommandHandler : IRequestHandler<CreateConcentrateCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IConcentrateRepository _repository;
        public CreateConcentrateCommandHandler(IMapper mapper,
            IConcentrateRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateConcentrateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Concentrate>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
