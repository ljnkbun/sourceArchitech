using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.WeavingReportSettingDetails;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingReportSettings
{
    public class UpdateWeavingReportSettingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int WeavingIEDId { get; set; }
        public SettingType SettingType { get; set; }
        public int NumberOfSplit { get; set; }
        public int Repeat { get; set; }
        public bool IsActive { set; get; }
        public ICollection<UpdateWeavingReportSettingDetailCommand> WeavingReportSettingDetails { get; set; }
    }

    public class UpdateWeavingReportSettingCommandHandler : IRequestHandler<UpdateWeavingReportSettingCommand, Response<int>>
    {
        private readonly IWeavingReportSettingRepository _repository;
        private readonly IMapper _mapper;

        public UpdateWeavingReportSettingCommandHandler(IWeavingReportSettingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateWeavingReportSettingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"WeavingReportSetting Not Found.");
            command.WeavingReportSettingDetails = command.WeavingReportSettingDetails.Select(x =>
            {
                x.Split = x.Split.Replace(" ", "");
                return x;
            }).ToList();
            entity.WeavingIEDId = command.WeavingIEDId;
            entity.SettingType = command.SettingType;
            entity.NumberOfSplit = command.NumberOfSplit;
            entity.Repeat = command.Repeat;
            entity.IsActive = command.IsActive;
            var dbWeavingReportSettingDetails = entity.WeavingReportSettingDetails;
            entity.WeavingReportSettingDetails = null;

            #region WeavingReportSettingDetail

            var dbWeavingReportSettingDetailModifieds = dbWeavingReportSettingDetails.Where(x => command.WeavingReportSettingDetails.Any(y => y.Id == x.Id)).Select(
                x =>
                {
                    var rs = _mapper.Map(command.WeavingReportSettingDetails.First(c => c.Id == x.Id), x);
                    rs.WeavingReportSettingId = command.Id;
                    return rs;
                });

            var newWeavingReportSettingDetailAddeds = command.WeavingReportSettingDetails.Where(x => x.Id == 0)
                .Select(x => _mapper.Map<WeavingReportSettingDetail>(x));

            var dbWeavingReportSettingDetailDeletes =
                dbWeavingReportSettingDetails.Where(x => dbWeavingReportSettingDetailModifieds.All(y => y.Id != x.Id));

            #endregion WeavingReportSettingDetail

            await _repository.UpdateWeavingReportSettingValueAsync(entity, new BaseUpdateEntity<WeavingReportSettingDetail>
            {
                LstDataUpdate = dbWeavingReportSettingDetailModifieds,
                LstDataAdd = newWeavingReportSettingDetailAddeds,
                LstDataDelete = dbWeavingReportSettingDetailDeletes
            });

            return new Response<int>(entity.Id);
        }
    }
}