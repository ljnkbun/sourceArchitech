using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingRoutingBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingRoutings
{
    public class UpdateSewingRoutingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string WFXOperationCode { get; set; }
        public string WFXOperationName { get; set; }
        public int LineNumber { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { set; get; }
        public virtual ICollection<SewingRoutingBOLModel> SewingRoutingBOLs { get; set; }
    }
    public class UpdateSewingRoutingCommandHandler : IRequestHandler<UpdateSewingRoutingCommand, Response<int>>
    {
        private readonly ISewingRoutingRepository _repository;
        private readonly IMapper _mapper;
        public UpdateSewingRoutingCommandHandler(ISewingRoutingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateSewingRoutingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"SewingRouting Not Found.");

            entity.WFXProcessCode = command.WFXProcessCode;
            entity.WFXProcessName = command.WFXProcessName;
            entity.WFXOperationCode = command.WFXProcessCode;
            entity.WFXOperationName = command.WFXOperationName;
            entity.LineNumber = command.LineNumber;
            entity.Deleted = command.Deleted;
            entity.IsActive = command.IsActive;
            entity.SewingRoutingBOLs = null;

            var newSewingRoutingBOLs = _mapper.Map<List<SewingRoutingBOL>>(command.SewingRoutingBOLs);
            decimal totalSMV = 0;
            foreach (var item in newSewingRoutingBOLs ?? Enumerable.Empty<SewingRoutingBOL>())
            {
                item.SewingRoutingId = entity.Id;
                totalSMV = totalSMV + item.TotalSMV;
            }
            entity.SMV = totalSMV;
            await _repository.UpdateSewingRoutingAsync(entity, newSewingRoutingBOLs);
            return new Response<int>(entity.Id);
        }
    }
}
