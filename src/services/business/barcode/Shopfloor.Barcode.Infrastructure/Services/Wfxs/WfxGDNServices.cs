using AutoMapper;
using Microsoft.Extensions.Logging;
using Shopfloor.Barcode.Application.Services.Wfxs;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;

namespace Shopfloor.Barcode.Infrastructure.Services.Wfxs
{
    public class WfxGDNServices : IWfxGDNServices
    {
        private readonly IMapper _mapper;
        private readonly IRequestClientService _requestClientService;
        private readonly ILogger<WfxGDNServices> _logger;

        public WfxGDNServices(IMapper mapper,
            IRequestClientService requestClientService,
            ILogger<WfxGDNServices> logger)
        {
            _mapper = mapper;
            _requestClientService = requestClientService;
            _logger = logger;
        }

        public async Task<IReadOnlyList<WfxGDN>> GetGDNsAsync()
        {
            try
            {
                var rs = await _requestClientService.GetResponseAsync<GetWfxGDNRequest, GetWfxGDNResponse>(new GetWfxGDNRequest
                {
                    WFXAPIGDNMovementData = new List<WFXAPIGDNMovementParams>
                    {
                        new(){
                            GDNNum = string.Empty,
                        }
                    }
                });

                var data = _mapper.Map<List<WfxGDN>>(rs?.Message?.Data);
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
