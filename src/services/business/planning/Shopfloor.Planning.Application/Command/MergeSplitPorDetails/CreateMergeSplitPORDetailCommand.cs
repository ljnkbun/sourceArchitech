using AutoMapper;
using MediatR;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Command.MergeSplitPORs
{
    public class CreateMergeSplitPORDetailCommand : IRequest<Response<int>>
    {
        public int FromPORId { get; set; }
        public int ToPORId { get; set; }
        public decimal Quantity { get; set; }
    }
    public class CreateMergeSplitPORDetailCommandHandler : IRequestHandler<CreateMergeSplitPORDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IMergeSplitPorDetailRepostiry _repository;
        public CreateMergeSplitPORDetailCommandHandler(IMapper mapper,
            IMergeSplitPorDetailRepostiry repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMergeSplitPORDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MergeSplitPorDetail>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
