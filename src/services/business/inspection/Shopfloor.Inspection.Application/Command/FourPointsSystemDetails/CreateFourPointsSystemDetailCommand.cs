using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.FourPointsSystemDetails
{
    public class CreateFourPointsSystemDetailCommand : IRequest<Response<int>>
    {
        public decimal? From { get; set; }
		public decimal? To { get; set; }
		public GradeType GradeType { get; set; }
    }
    public class CreateFourPointsSystemDetailCommandHandler : IRequestHandler<CreateFourPointsSystemDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFourPointsSystemDetailRepository _repository;
        public CreateFourPointsSystemDetailCommandHandler(IMapper mapper,
            IFourPointsSystemDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFourPointsSystemDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<FourPointsSystemDetail>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
