using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests.Masters.Factories;
using Shopfloor.EventBus.Models.Requests.Masters.Lines;
using Shopfloor.EventBus.Models.Requests.Masters.Machines;
using Shopfloor.EventBus.Models.Requests.Masters.PlanningGroups;
using Shopfloor.EventBus.Models.Responses.Masters.Factories;
using Shopfloor.EventBus.Models.Responses.Masters.Lines;
using Shopfloor.EventBus.Models.Responses.Masters.Machines;
using Shopfloor.EventBus.Models.Responses.Masters.PlanningGroupFactories;
using Shopfloor.EventBus.Services;
using Shopfloor.Planning.Application.Models.Articles;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.Articles
{
    public class GetArticleHistoryQuery : IRequest<Response<IReadOnlyList<ArticleHistoryModel>>>
    {
        public string ArticleCode { get; set; }
    }

    public class GetArticleHistoryQueryHandler : IRequestHandler<GetArticleHistoryQuery, Response<IReadOnlyList<ArticleHistoryModel>>>
    {
        private readonly IStripFactoryRepository _stripFactoryRepository;
        private readonly IRequestClientService _requestClientService;
        private readonly IStripFactoryScheduleRepository _stripFactoryScheduleRepository;


        public GetArticleHistoryQueryHandler(IRequestClientService requestClientService
            , IStripFactoryRepository stripFactoryRepository
            , IStripFactoryScheduleRepository stripFactoryScheduleRepository)
        {
            _requestClientService = requestClientService;
            _stripFactoryRepository = stripFactoryRepository;
            _stripFactoryScheduleRepository = stripFactoryScheduleRepository;
        }

        public async Task<Response<IReadOnlyList<ArticleHistoryModel>>> Handle(GetArticleHistoryQuery request, CancellationToken cancellationToken)
        {
            var stripFactoryShedules = await _stripFactoryScheduleRepository.GetStripFactorySheduleAsync<ArticleHistoryModel>(request.ArticleCode);
            var stripFactories = await _stripFactoryRepository.GetHistoryAsync<ArticleHistoryModel>(request.ArticleCode);
            var result = new List<ArticleHistoryModel>();

            #region Globals
            // Factory from Master
            var factoryResponse = await _requestClientService.GetResponseAsync<GetFactoriesRequest, GetFactoriesResponse>(new(), cancellationToken);
            var factoryModel = factoryResponse.Message.Data;

            // Lines/Machines from master
            var linesResponse = await _requestClientService.GetResponseAsync<GetLinesRequest, GetLinesResponse>(new(), cancellationToken);
            var lineModel = linesResponse.Message.Data;

            var machinesResponse = await _requestClientService.GetResponseAsync<GetMachinesRequest, GetMachinesResponse>(new(), cancellationToken);
            var machineModel = machinesResponse.Message.Data;
            #endregion

            foreach (var stripFactory in stripFactories)
            {
                var lstStripFactoryShedule = stripFactoryShedules.Where(x => x.StripFactoryId == stripFactory.Id).ToList();
                if (lstStripFactoryShedule.Any())
                    result.AddRange(lstStripFactoryShedule);
                else
                    result.Add(stripFactory);
            }

            foreach (var item in result)
            {
                item.FactoryName = factoryModel.Find(x => x.Id == item.PlanningGroupFactoryId)?.Name;
                item.LineName = item.LineId.HasValue ? lineModel.Find(x => x.Id == item.LineId.Value).Name : null;
                item.MachineName = item.MachineId.HasValue ? machineModel.Find(x => x.Id == item.MachineId.Value).Name : null;
            }

            return new Response<IReadOnlyList<ArticleHistoryModel>>(result);
        }
    }
}
