using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests.Ambassadors.Wfxs;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;
using Shopfloor.EventBus.Services;

namespace Shopfloor.Master.Application.Command.SubCategories
{
    public class WfxSyncDataCommand : IRequest<Response<bool>>
    {
    }

    public class WfxSyncDataCommandHandler : IRequestHandler<WfxSyncDataCommand, Response<bool>>
    {
        #region constant

        const string Yarns = "Yarns";
        const string Textiles = "Textiles/Fabric";
        const string Trims = "Trims";
        const string Apparel = "Apparel";
        const string Fiber = "Fiber";
        const string FixedAsset = "Fixed Asset";
        const string Miscellaneous = "Miscellaneous";
        const string Services = "Services";

        #endregion

        private readonly IRequestClientService _requestClientService;


        public WfxSyncDataCommandHandler(IRequestClientService requestClientService)
        {
            _requestClientService = requestClientService;
        }

        public Task<Response<bool>> Handle(WfxSyncDataCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task DoSyncDataAsync()
        {
            var datas = new List<WfxWebSharedDto>();

            //Yarns
            var yarnsData = await SyncDataASync(Yarns);
            datas.AddRange(yarnsData);
            
            //Textiles
            var textilesData = await SyncDataASync(Textiles);
            datas.AddRange(textilesData);

            //Trims
            var trimsData = await SyncDataASync(Trims);
            datas.AddRange(trimsData);

            //Apparel
            var apparelData = await SyncDataASync(Apparel);
            datas.AddRange(apparelData);

            //Fiber
            var fiberData = await SyncDataASync(Fiber);
            datas.AddRange(fiberData);

            //FixedAsset
            var fixedAssetData = await SyncDataASync(FixedAsset);
            datas.AddRange(fixedAssetData);

            //Miscellaneous
            var miscellaneousData = await SyncDataASync(Miscellaneous);
            datas.AddRange(miscellaneousData);

            //Services
            var servicesData = await SyncDataASync(Services);
            datas.AddRange(servicesData);

            await SaveSyncDataAsync(datas);
        }


        // Sync Data
        private async Task<List<WfxWebSharedDto>> SyncDataASync(string category)
        {
            var rs = await _requestClientService.GetResponseAsync<GetWfxWebSharedRequest, GetWfxWebSharedResponse>(new GetWfxWebSharedRequest
            {
                Category = category,
            });

            return rs.Message.Data;
        }

        // Save Sync Data
        private async Task SaveSyncDataAsync(List<WfxWebSharedDto> dtos)
        {

        }
    }
}
