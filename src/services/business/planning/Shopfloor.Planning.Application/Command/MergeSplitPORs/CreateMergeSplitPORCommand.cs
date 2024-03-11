using AutoMapper;
using MediatR;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Command.MergeSplitPORs
{
    public class CreateMergeSplitPORCommand : IRequest<Response<int>>
    {
        public int FromPORId { get; set; }
		public int ToPORId { get; set; }
		public decimal Quantity { get; set; }
    }
    public class CreateMergeSplitPORCommandHandler : IRequestHandler<CreateMergeSplitPORCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IMergeSplitPORRepository _repository;
        public CreateMergeSplitPORCommandHandler(IMapper mapper,
            IMergeSplitPORRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMergeSplitPORCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MergeSplitPOR>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
