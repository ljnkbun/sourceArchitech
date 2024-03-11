using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingReportSettingDetails
{
    public class CreateWeavingReportSettingDetailCommand : IRequest<Response<int>>
    {
        public int WeavingReportSettingId { get; set; }
        public int GroupIndex { get; set; }
        public string Split { get; set; }
        public int Repeat { get; set; }
    }

    public class CreateWeavingReportSettingDetailCommandHandler : IRequestHandler<CreateWeavingReportSettingDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingReportSettingDetailRepository _repository;

        public CreateWeavingReportSettingDetailCommandHandler(IMapper mapper,
            IWeavingReportSettingDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingReportSettingDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingReportSettingDetail>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}