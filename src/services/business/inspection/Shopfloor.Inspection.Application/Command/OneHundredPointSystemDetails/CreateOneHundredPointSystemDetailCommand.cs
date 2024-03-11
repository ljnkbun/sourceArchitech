using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.OneHundredPointSystemDetails
{
    public class CreateOneHundredPointSystemDetailCommand : IRequest<Response<int>>
    {
        public decimal? FromKg { get; set; }
		public decimal? ToKg { get; set; }
		public int? FromDefect { get; set; }
		public int? ToDefect { get; set; }
		public OneHundredPointType Point { get; set; }
    }
    public class CreateOneHundredPointSystemDetailCommandHandler : IRequestHandler<CreateOneHundredPointSystemDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IOneHundredPointSystemDetailRepository _repository;
        public CreateOneHundredPointSystemDetailCommandHandler(IMapper mapper,
            IOneHundredPointSystemDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateOneHundredPointSystemDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<OneHundredPointSystemDetail>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
