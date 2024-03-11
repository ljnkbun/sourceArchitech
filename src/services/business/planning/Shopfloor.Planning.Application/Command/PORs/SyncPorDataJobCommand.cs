using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Dtos;
using Shopfloor.EventBus.Models.Requests.Ambassadors.Wfxs;
using Shopfloor.EventBus.Services;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.PORs
{
    public class SyncPorDataJobCommand : IRequest<Response<bool>>
    {
        public string category { get; set; }
        public string ocNo { get; set; }
        public string lastDays { get; set; }
    }

    public class SyncPorDataJobCommandHandler : IRequestHandler<SyncPorDataJobCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IPORRepository _repository;
        private readonly IRequestClientService _requestClientService;

        public SyncPorDataJobCommandHandler(IMapper mapper 
            , IPORRepository repository
            , IRequestClientService requestClientService)
        {
            _mapper = mapper;
            _repository = repository;
            _requestClientService = requestClientService;
        }

        public async Task<Response<bool>> Handle(SyncPorDataJobCommand request, CancellationToken cancellationToken)
        {
            var entities = await SyncPorAsync(request);
            return new Response<bool>(await _repository.SaveWfxPORSync(entities));
        }

        private async Task<List<POR>> SyncPorAsync(SyncPorDataJobCommand request)
        {
            var rs = await _requestClientService.GetResponseAsync<GetWfxPorRequest, GetPorSyncResponse>(new GetWfxPorRequest
            {
                Category = request.category,
                GETLastDays = request.lastDays,
                OCNO = request.ocNo,
            });

            var result = _mapper.Map<List<POR>>(rs.Message.Data);

            return result;
        }
    }
}
