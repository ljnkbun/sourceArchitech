using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingRoutingBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingRoutings
{
    public class CreateSewingRoutingCommand : IRequest<Response<int>>
    {
        public int SewingIEDId { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string WFXOperationCode { get; set; }
        public string WFXOperationName { get; set; }
        public int LineNumber { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<SewingRoutingBOLModel> SewingRoutingBOLs { get; set; }
    }
    public class CreateSewingRoutingCommandHandler : IRequestHandler<CreateSewingRoutingCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingRoutingRepository _repository;
        public CreateSewingRoutingCommandHandler(IMapper mapper,
            ISewingRoutingRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingRoutingCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingRouting>(request);
            entity.SMV = entity.SewingRoutingBOLs.Sum(s => s.SMV);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
