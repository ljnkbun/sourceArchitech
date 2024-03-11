using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRappoMarks
{
    public class CreateWeavingRappoMarkCommand : IRequest<Response<int>>
    {
        public int WeavingRappoId { get; set; }
        public int ColumnNo { get; set; }
        public int PatternIndex { get; set; }
        public bool Type { get; set; }
    }
    public class CreateWeavingRappoMarkCommandHandler : IRequestHandler<CreateWeavingRappoMarkCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingRappoMarkRepository _repository;
        public CreateWeavingRappoMarkCommandHandler(IMapper mapper,
            IWeavingRappoMarkRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingRappoMarkCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingRappoMark>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
