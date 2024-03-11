using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.WeavingReportSettingDetails;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingReportSettings
{
    public class CreateWeavingReportSettingCommand : IRequest<Response<int>>
    {
        public int WeavingIEDId { get; set; }
        public SettingType SettingType { get; set; }
        public int NumberOfSplit { get; set; }
        public int Repeat { get; set; }
        public ICollection<CreateWeavingReportSettingDetailCommand> WeavingReportSettingDetails { get; set; }
    }

    public class CreateWeavingReportSettingCommandHandler : IRequestHandler<CreateWeavingReportSettingCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingReportSettingRepository _repository;

        public CreateWeavingReportSettingCommandHandler(IMapper mapper,
            IWeavingReportSettingRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingReportSettingCommand request, CancellationToken cancellationToken)
        {
            request.WeavingReportSettingDetails = request.WeavingReportSettingDetails.Select(x =>
            {
                x.Split = x.Split.Replace(" ", "");
                return x;
            }).ToList();
            var entity = _mapper.Map<WeavingReportSetting>(request);
       
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}