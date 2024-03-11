using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingIEDs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingIEDs
{
    public class GetWeavingIEDReportsQuery : IRequest<Response<DataReportWeavingIEDModel>>
    {
        public int Id { get; set; }
    }

    public class GetWeavingIEDReportsQueryHandler : IRequestHandler<GetWeavingIEDReportsQuery, Response<DataReportWeavingIEDModel>>
    {
        private readonly IWeavingIEDRepository _repository;

        public GetWeavingIEDReportsQueryHandler(IWeavingIEDRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<DataReportWeavingIEDModel>> Handle(GetWeavingIEDReportsQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWeavingIEDByIdAsync(query.Id);
            if (entity == null) return new($"WeavingIED Not Found (Id:{query.Id}).");
            var dataReport = new DataReportWeavingIEDModel();
            var backgroundRappo = entity.WeavingRappo
                .WeavingRappoMatrics
                .Where(x => x.BackgroundType == 1 && x.VerticleYarn != null)
                .ToList();
            var marginRappo = entity.WeavingRappo
                .WeavingRappoMatrics
                .Where(x => x.BackgroundType == 0 && x.VerticleYarn != null)
                .ToList();
            dataReport.VerticalRappo = GetVerticalRappo(query.Id, marginRappo, backgroundRappo);
            dataReport.HorizontalRappo = GetHorizontalRappo(query.Id, marginRappo);
            dataReport.HookGoBoard = GetHookGoBoard(query.Id, marginRappo, backgroundRappo, entity.WeavingReportSetting?.WeavingReportSettingDetails);
            dataReport.CottonDottingBoard = GetCottonDottingBoard(query.Id, backgroundRappo.GroupBy(x => x.ColumnIndex).Count(), backgroundRappo, entity.WeavingRappo.WeavingRappoMarks);
            return new Response<DataReportWeavingIEDModel>(dataReport);
        }

        private VerticalRappo GetVerticalRappo(int id, List<WeavingRappoMatric> marginRappo, List<WeavingRappoMatric> backgroundRappo)
        {
            var verticalRappo = new VerticalRappo
            {
                MarginVerticleRappos = marginRappo
                    .GroupBy(x => x.VerticleYarnId)
                    .Select(x =>
                    {
                        var dataConvert = x.FirstOrDefault();
                        var dataMarginRappo = new MarginBackgroundRappo
                        {
                            YarnCode = dataConvert?.VerticleYarn?.YarnCode,
                            YarnName = dataConvert?.VerticleYarn?.YarnName,
                            YarnId = dataConvert!.VerticleYarnId!.Value,
                            WeavingIEDId = id,
                            Quantity = x.GroupBy(y => y!.ColumnIndex).Count()
                        };
                        return dataMarginRappo;
                    }).ToList(),
                BackgroundVerticalRappos = backgroundRappo
                    .GroupBy(x => x.LoopIndex)
                    .Select(x =>
                    {

                        var maxSlotIndex = x.Max(zx => zx.SlotIndex);
                        var repeatRappo = new RepeatRappo
                        {
                            Repeat = maxSlotIndex,
                            MarginBackgroundRappo = new List<MarginBackgroundRappo>()
                        };
                        foreach (var item in x.Where(y => y.SlotIndex == maxSlotIndex).GroupBy(y => new { y.VerticleYarnId }))
                        {
                            var dataConvert = item.FirstOrDefault();
                            var dataMarginRappo = new MarginBackgroundRappo
                            {
                                YarnCode = dataConvert?.VerticleYarn?.YarnCode,
                                YarnName = dataConvert?.VerticleYarn?.YarnName,
                                YarnId = dataConvert!.VerticleYarnId!.Value,
                                WeavingIEDId = id,
                                Quantity = item.GroupBy(zx => zx.ColumnIndex).Count()
                            };
                            repeatRappo.MarginBackgroundRappo.Add(dataMarginRappo);
                        }

                        return repeatRappo;
                    })
                    .ToList()
            };
            return verticalRappo;
        }

        private HorizontalRappo GetHorizontalRappo(int id, List<WeavingRappoMatric> marginRappo)
        {
            var horizontalRappo = new HorizontalRappo
            {
                MarginHorizontalRappos = marginRappo
                    .GroupBy(x => x.HorizontalYarnId)
                    .Select(x =>
                    {
                        var dataConvert = x.FirstOrDefault();
                        var dataMarginRappo = new MarginBackgroundRappo
                        {
                            YarnCode = dataConvert?.HorizontalYarn?.YarnCode,
                            YarnName = dataConvert?.HorizontalYarn?.YarnName,
                            YarnId = dataConvert.HorizontalYarnId,
                            WeavingIEDId = id,
                            Quantity = x.GroupBy(y => y.RowIndex).Count()
                        };
                        return dataMarginRappo;
                    }).ToList()
            };

            return horizontalRappo;
        }

        private HookGoBoard GetHookGoBoard(int id, List<WeavingRappoMatric> marginRappo, List<WeavingRappoMatric> backgroundRappo, ICollection<WeavingReportSettingDetail> weavingReportSettingDetail)
        {
            var hookGoBoard = new HookGoBoard
            {
                MarginHooks = marginRappo
                    .GroupBy(x => x.RowIndex)
                    .Select(x =>
                    {
                        var dataConvert = x.FirstOrDefault();
                        var dataHookGoBoard = new DataHookGoBoard
                        {
                            YarnCode = dataConvert?.HorizontalYarn?.YarnCode,
                            YarnName = dataConvert?.HorizontalYarn?.YarnName,
                            YarnId = dataConvert!.HorizontalYarnId,
                            WeavingIEDId = id
                        };
                        return dataHookGoBoard;
                    }).ToList(),
                BackgroundHooks = weavingReportSettingDetail
                    .GroupBy(x => x.Repeat)
                    .Select(groupReportSettingDetail =>
                    {
                        var reportSettingDetail = groupReportSettingDetail.FirstOrDefault();
                        var repeatHookGoBoard = new RepeatHookGoBoard
                        {
                            Repeat = groupReportSettingDetail.Count(),
                            GroupHookGoBoards = new List<GroupHookGoBoard>()
                        };
                        foreach (var s in reportSettingDetail!.Split.Split(","))
                        {
                            var groupHookGoBoard = new GroupHookGoBoard
                            {
                                SplitHookGoBoard = backgroundRappo
                                    .Where(x => x.SlotIndex == int.Parse(s)).GroupBy(x => x.ColumnIndex).Select(x =>
                                    {
                                        var dataColumn = x.FirstOrDefault();
                                        var rs = new DataHookGoBoard
                                        {
                                            YarnCode = dataColumn!.VerticleYarn!.YarnCode,
                                            YarnName = dataColumn!.VerticleYarn!.YarnName,
                                            YarnId = dataColumn!.VerticleYarn!.Id,
                                            WeavingIEDId = id
                                        };
                                        return rs;
                                    }).ToList()
                            };
                            repeatHookGoBoard.GroupHookGoBoards.Add(groupHookGoBoard);
                        }
                        return repeatHookGoBoard;
                    }).ToList()
            };
            return hookGoBoard;
        }

        private CottonDottingBoard GetCottonDottingBoard(int id, int maxIndexMargin, List<WeavingRappoMatric> backgroundRappo, ICollection<WeavingRappoMark> weavingRappoMarks)
        {
            var marks = weavingRappoMarks.Where(x => x.Type);
            var maxPatternIndex = marks?.Max(x => x.PatternIndex);
            var filterDataGenerated = new List<FilterGenerated>();
            var index = 0;
            foreach (var dataRows in backgroundRappo
                         .OrderByDescending(x => x.SlotIndex)
                         .ThenBy(x => x.ColumnIndex)
                         .GroupBy(x => new { x.SlotIndex, x.ColumnIndex }))
            {
                var mark = marks.FirstOrDefault(x => x.ColumnNo == index + maxIndexMargin);
                filterDataGenerated.AddRange(dataRows.Select(matric => new FilterGenerated
                {
                    ColumnNo = mark?.ColumnNo ?? -1,
                    PatternIndex = mark?.PatternIndex ?? -1,
                    WeavingRappoId = mark?.WeavingRappoId ?? -1,
                    Type = mark?.Type ?? false,
                    YarnId = matric.HorizontalYarn.Id,
                    YarnCode = matric.HorizontalYarn.YarnCode,
                    YarnName = matric.HorizontalYarn.YarnName,
                    FilterPatternIndex = maxPatternIndex.Value - (mark?.PatternIndex ?? 0) + 1,
                    ColumnIndex = matric.ColumnIndex,
                    RowIndex = matric.RowIndex,
                    SlotIndex = matric.SlotIndex,
                    LoopIndex = matric.LoopIndex,
                    WeavingIEDId = id
                }));
                index++;
            }
            var cottonDottingBoard = new CottonDottingBoard
            {
                GroupDataCottonDottingBoard = filterDataGenerated
                    .GroupBy(x => x.RowIndex)
                    .Select(itemRows =>
                    {
                        var itemDataYarn = itemRows.First();
                        var distinctPatternIndexes = itemRows.Select(item => item.FilterPatternIndex).Distinct().OrderBy(x => x).ToList();
                        var itemData = new DataCottonDottingBoard
                        {
                            YarnCode = itemDataYarn.YarnCode,
                            YarnName = itemDataYarn.YarnName,
                            YarnId = itemDataYarn.YarnId,
                            WeavingIEDId = itemDataYarn.WeavingIEDId,
                            RowIndex = itemDataYarn.RowIndex,
                            DataPatternIndex = distinctPatternIndexes.ToList()
                        };

                        return itemData;
                    })
                    .OrderByDescending(x => x.RowIndex)
                    .ToList()
            };

            return cottonDottingBoard;
        }
    }
}