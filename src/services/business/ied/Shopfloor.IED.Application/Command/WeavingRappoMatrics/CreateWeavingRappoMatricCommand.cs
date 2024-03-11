using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRappoMatrics
{
    public class CreateWeavingRappoMatricCommand : IRequest<Response<int>>
    {
        public int WeavingRappoId { get; set; }
        public int SlotIndex { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int LoopIndex { get; set; }
        public int HorizontalYarnId { get; set; }
        public int? VerticleYarnId { get; set; }
        public int BackgroundType { get; set; }
    }
    public class CreateWeavingRappoMatricCommandHandler : IRequestHandler<CreateWeavingRappoMatricCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingRappoMatricRepository _repository;
        public CreateWeavingRappoMatricCommandHandler(IMapper mapper,
            IWeavingRappoMatricRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingRappoMatricCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingRappoMatric>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
