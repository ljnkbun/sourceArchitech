using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.PORDetails;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.MergeSplitPORs
{
    public class SplitPORCommand : IRequest<Response<POR>>
    {
        public int PORId { get; set; }
        public ICollection<SplitPorDetailModel> SplitPorDetailModels { get; set; }
    }
    public class SplitPORCommandHandler : IRequestHandler<SplitPORCommand, Response<POR>>
    {
        private readonly IMapper _mapper;
        private readonly IPORRepository _repository;

        public SplitPORCommandHandler(IMapper mapper
            , IPORRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<POR>> Handle(SplitPORCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.PORId);
            if(entity == null) return new($"POR Not Found.");
            var pORDetails = _mapper.Map<List<PORDetail>>(command.SplitPorDetailModels);
            var result = await _repository.SplitPORAsync(entity, pORDetails);
            return new Response<POR>(result);
        }
    }
}
