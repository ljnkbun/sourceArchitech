using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.FourPointsSystems
{
    public class CreateFourPointsSystemCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ProductGroup { get; set; }

    }
    public class CreateFourPointsSystemCommandHandler : IRequestHandler<CreateFourPointsSystemCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFourPointsSystemRepository _repository;
        public CreateFourPointsSystemCommandHandler(IMapper mapper,
            IFourPointsSystemRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFourPointsSystemCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<FourPointsSystem>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
