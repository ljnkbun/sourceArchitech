using AutoMapper;
using Microsoft.Extensions.Logging;
using Shopfloor.Barcode.Application.Services.Wfxs;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;

namespace Shopfloor.Barcode.Infrastructure.Services.Wfxs
{
    public class WfxPOArticleServices : IWfxPOArticleServices
    {
        private readonly IMapper _mapper;
        private readonly IRequestClientService _requestClientService;
        private readonly IWfxPOArticleRepository _wfxPOArticleRepository;
        private readonly ILogger<WfxPOArticleServices> _logger;

        public WfxPOArticleServices(IMapper mapper,
            IRequestClientService requestClientService,
            IWfxPOArticleRepository wfxPOArticleRepository,
            ILogger<WfxPOArticleServices> logger)
        {
            _mapper = mapper;
            _requestClientService = requestClientService;
            _wfxPOArticleRepository = wfxPOArticleRepository;
            _logger = logger;
        }

        public async Task<IReadOnlyList<WfxPOArticle>> GetPOArticlesAsync()
        {
            try
            {
                var checkExisted = await _wfxPOArticleRepository.Existed();
                MassTransit.Response<GetWfxPOArticleResponse> rs = null;
                if (!checkExisted)
                {
                    rs = await _requestClientService.GetResponseAsync<GetWfxPOArticleRequest, GetWfxPOArticleResponse>(new GetWfxPOArticleRequest
                    {
                        SearchDics = new Dictionary<string, string> {
                        { "OrderType", "PO" }
                    }
                    });
                }
                else
                {
                    var lastDate = await _wfxPOArticleRepository.GetLastDate();

                    rs = await _requestClientService.GetResponseAsync<GetWfxPOArticleRequest, GetWfxPOArticleResponse>(new GetWfxPOArticleRequest
                    {
                        SearchDics = new Dictionary<string, string> {
                        { "OrderType", "PO" },
                        { "FromOrderDate", lastDate.ToString("yyyy/MM/dd") },
                        { "ToOrderDate", DateTime.Now.ToString("yyyy/MM/dd")  }
                    }
                    });
                }
                var data = _mapper.Map<List<WfxPOArticle>>(rs?.Message?.Data);
                return data;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Error SearchArticle: {e.FullMessage()}");
                return null;
            }
        }
    }
}
