using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.AQLs
{
    public class CreateAQLCommand : IRequest<Response<int>>
    {
        public int AQLVersionId { get; set; }
		public int LotSizeFrom { get; set; }
		public int LotSizeTo { get; set; }
		public int SampleSize { get; set; }
		public int? Accept { get; set; }
		public int? Reject { get; set; }
    }
    public class CreateAQLCommandHandler : IRequestHandler<CreateAQLCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IAQLRepository _repository;
        public CreateAQLCommandHandler(IMapper mapper,
            IAQLRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAQLCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<AQL>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
