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
    public class WfxGDIServices : IWfxGDIServices
    {
        private readonly IMapper _mapper;
        private readonly IRequestClientService _requestClientService;
        private readonly IWfxGDIRepository _wfxGDIRepository;
        private readonly ILogger<WfxGDIServices> _logger;

        public WfxGDIServices(IMapper mapper,
            IRequestClientService requestClientService,
            IWfxGDIRepository wfxGDIRepository,
            ILogger<WfxGDIServices> logger)
        {
            _mapper = mapper;
            _requestClientService = requestClientService;
            _wfxGDIRepository = wfxGDIRepository;
            _logger = logger;
        }

        public async Task<IReadOnlyList<WfxGDI>> GetGDIsAsync()
        {
            try
            {
                var checkExisted = await _wfxGDIRepository.Existed();
                MassTransit.Response<GetWfxGDIResponse> rs = null;
                var fromDate = DateTime.Now;

                if (!checkExisted)
                {
                    fromDate = new DateTime((fromDate.Year - 1), 1, 1);
                }
                else
                {
                    fromDate = await _wfxGDIRepository.GetLastDate();
                }

                rs = await _requestClientService.GetResponseAsync<GetWfxGDIRequest, GetWfxGDIResponse>(new GetWfxGDIRequest
                {
                    WFXAPIGDIMovementData = new List<WFXAPIGDIMovementParams>
                    {
                        new(){
                            GDIDateFrom = fromDate.ToString("MM/dd/yyyy"),
                            GDIDateTo = DateTime.Now.ToString("MM/dd/yyyy"),
                        }
                    }
                });

                var data = _mapper.Map<List<WfxGDI>>(rs?.Message?.Data);
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
