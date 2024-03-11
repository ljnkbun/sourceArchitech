using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests.Ambassadors.Wfxs;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;
using Shopfloor.EventBus.Services;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.OperationLibraries
{
    public class WfxSyncOperationLibraryCommand : IRequest<Response<bool>>
    {

    }
    public class WfxSyncOperationLibraryCommandHandler : IRequestHandler<WfxSyncOperationLibraryCommand, Response<bool>>
    {
        private readonly IRequestClientService _requestClientService;
        private readonly IOperationLibraryRepository _repository;
        private readonly IProcessRepository _processRepository;
        public WfxSyncOperationLibraryCommandHandler(IOperationLibraryRepository repository,
            IRequestClientService requestClientService,
            IProcessRepository processRepository)
        {
            _repository = repository;
            _requestClientService = requestClientService;
            _processRepository = processRepository;
        }
        public async Task<Response<bool>> Handle(WfxSyncOperationLibraryCommand command, CancellationToken cancellationToken)
        {
            var rs = await _requestClientService.GetResponseAsync<GetWFXOperationLibraryRequest, WFXOperationLibraryResponse>(new GetWFXOperationLibraryRequest
            {
                ObjectType = "OperationLibrary",
            });
            if (rs != null && rs.Message.Data != null)
            {
                var allProcess = await _processRepository.GetAllAsync();
                var allOperations = await _repository.GetAllAsync();
                var subDataGroup = rs.Message.Data.GroupBy(x => new { x.OperationID, x.Operation });
                var lstAdd = subDataGroup
                    .Where(x => !allOperations.Any(y => y.WFXOperationId == Convert.ToInt32(x.Key.OperationID)))
                    .Select(x => new OperationLibrary
                    {
                        Name = x.Key.Operation,
                        Code = Convert.ToInt32(x.Key.OperationID).ToString(),
                        WFXOperationId = Convert.ToInt32(x.Key.OperationID),
                        ProcessId = allProcess.FirstOrDefault(y => y.WFXProcessId == Convert.ToInt32(x.FirstOrDefault().ProcessID))?.Id ?? 0,

                    }).Where(x => x.ProcessId > 0).ToList();
                var lstUpdate = allOperations.Where(x =>
                                subDataGroup.Any(y => IsChange(x, y.FirstOrDefault(), allProcess.ToList()))).ToList();
                foreach (var x in lstUpdate)
                {
                    var data = subDataGroup.FirstOrDefault(y => Convert.ToInt32(y.FirstOrDefault().OperationID) == x.WFXOperationId).FirstOrDefault();
                    x.Code = Convert.ToInt32(data.OperationID).ToString();
                    x.Name = data.Operation;
                    x.ProcessId = allProcess.FirstOrDefault(y => y.WFXProcessId == Convert.ToInt32(data.ProcessID))?.Id ?? 0;
                }
                await _repository.InsertUpdateList(lstAdd, lstUpdate);
            }
            return new Response<bool>(true);
        }
        bool IsChange(OperationLibrary entity, WFXOperationLibrary data, List<Process> processes)
        {
            return entity.WFXOperationId == Convert.ToInt32(data.OperationID) && (entity.Name != data.Operation
                 || entity.ProcessId != processes.FirstOrDefault(x => x.WFXProcessId == Convert.ToInt32(data.ProcessID))?.Id);
        }
    }
}
