using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingDetailStructures
{
    public class CreateWeavingDetailStructureCommand : IRequest<Response<int>>
    {
        public int WeavingIEDId { get; set; }
        public int? LineNumber { get; set; }
        public StructureType StructureType { get; set; }
        public int Denting { get; set; }
        public int DentSplit { get; set; }
        public int Total { get; set; }
    }
    public class CreateWeavingDetailStructureCommandHandler : IRequestHandler<CreateWeavingDetailStructureCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingDetailStructureRepository _repository;
        public CreateWeavingDetailStructureCommandHandler(IMapper mapper,
            IWeavingDetailStructureRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingDetailStructureCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingDetailStructure>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
