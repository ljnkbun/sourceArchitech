using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Divisions
{
    public class CreateDivisionCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateDivisionCommandHandler : IRequestHandler<CreateDivisionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDivisionRepository _repository;
        public CreateDivisionCommandHandler(IMapper mapper,
            IDivisionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDivisionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Division>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
