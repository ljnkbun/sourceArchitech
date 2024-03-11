using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingDetailStructures;
using Shopfloor.IED.Application.Models.WeavingRappos;
using Shopfloor.IED.Application.Models.WeavingRusticFabricSpecs;
using Shopfloor.IED.Application.Models.WeavingYarns;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingSpecifications
{
    public class CreateWeavingRappoSpecificationCommand : IRequest<Response<bool>>
    {
        public int WeavingIEDId { get; set; }
        public IEnumerable<UpdateCreateWeavingYarnModel> WeavingYarns { get; set; }
        public UpdateCreateWeavingRappoModel WeavingRappo { get; set; }
        public UpdateCreateWeavingRusticFabricSpec WeavingRusticFabricSpec { get; set; }
        public IEnumerable<UpdateCreateWeavingDetailStructure> WeavingDetailStructures { get; set; }
    }

    public class CreateWeavingRappoSpecificationCommandHandler : IRequestHandler<CreateWeavingRappoSpecificationCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingSpecificationRepository _weavingSpecification;
        private readonly IWeavingYarnRepository _weavingYarn;
        private readonly IWeavingDetailStructureRepository _weavingDetailStructure;
        private readonly IWeavingRappoRepository _weavingRappo;
        private readonly IWeavingRusticFabricSpecRepository _weavingRusticFabricSpec;

        public CreateWeavingRappoSpecificationCommandHandler(IMapper mapper,
            IWeavingSpecificationRepository weavingSpecification, IWeavingYarnRepository weavingYarn, IWeavingDetailStructureRepository weavingDetailStructure, IWeavingRappoRepository weavingRappo, IWeavingRusticFabricSpecRepository weavingRusticFabricSpec)
        {
            _weavingSpecification = weavingSpecification;
            _weavingYarn = weavingYarn;
            _weavingDetailStructure = weavingDetailStructure;
            _weavingRappo = weavingRappo;
            _weavingRusticFabricSpec = weavingRusticFabricSpec;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateWeavingRappoSpecificationCommand request, CancellationToken cancellationToken)
        {
            WeavingRappo rappo;
            WeavingRusticFabricSpec spec;
            var structures = new BaseUpdateEntity<WeavingDetailStructure>();
            var weavingYarns = new BaseUpdateEntity<WeavingYarn>();
            var weavingRappoMatrics = new BaseUpdateEntity<WeavingRappoMatric>();
            var weavingRappoMarks = new BaseUpdateEntity<WeavingRappoMark>();

            #region WeavingRappo

            if (request.WeavingRappo.Id != 0)
            {
                rappo = await _weavingRappo.GetWeavingRappoByIdAsync(request.WeavingRappo.Id);
                if (rappo != null)
                {
                    rappo.WeavingIEDId = request.WeavingIEDId;
                    rappo.Line = request.WeavingRappo.Line;
                    rappo.WarpPerMarginDentSplit = request.WeavingRappo.WarpPerMarginDentSplit;
                    rappo.WarpPerContentDentSplit = request.WeavingRappo.WarpPerContentDentSplit;
                    rappo.TotalRappo = request.WeavingRappo.TotalRappo;
                    rappo.AdditionYarn = request.WeavingRappo.AdditionYarn;
                    rappo.VerticalRappoComment = request.WeavingRappo.VerticalRappoComment;
                    rappo.HorizontalRappoComment = request.WeavingRappo.HorizontalRappoComment;
                    rappo.DrawingComment = request.WeavingRappo.DrawingComment;
                    var dbWeavingRappoMatrics = rappo.WeavingRappoMatrics;
                    rappo.WeavingRappoMatrics = null;

                    var dbWeavingRappoMarkDeletes = rappo.WeavingRappoMarks;
                    rappo.WeavingRappoMarks = null;

                    #region WeavingRappoMarks

                    var newWeavingRappoMarkAddeds = request.WeavingRappo.WeavingRappoMarks
                        .Select(x =>
                        {
                            var data = _mapper.Map<WeavingRappoMark>(x);
                            data.Id = 0;
                            data.WeavingRappoId = rappo.Id;
                            return data;
                        });

                    #endregion WeavingRappoMarks

                    #region WeavingRappoMatrics

                    var dbWeavingRappoMatricModifieds = dbWeavingRappoMatrics.Where(x => request.WeavingRappo.WeavingRappoMatrics.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(request.WeavingRappo.WeavingRappoMatrics.First(c => c.Id == x.Id), x));

                    var newWeavingRappoMatricAddeds = request.WeavingRappo.WeavingRappoMatrics.Where(x => x.Id <= 0)
                        .Select(x =>
                        {
                            var data = _mapper.Map<WeavingRappoMatric>(x);
                            data.Id = 0;
                            data.WeavingRappoId = rappo.Id;
                            return data;
                        });
                    var dbWeavingRappoMatricDeletes =
                        dbWeavingRappoMatrics.Where(x => dbWeavingRappoMatricModifieds.All(y => y.Id != x.Id));

                    #endregion WeavingRappoMatrics

                    weavingRappoMarks.LstDataUpdate = new List<WeavingRappoMark>(); ;
                    weavingRappoMarks.LstDataAdd = newWeavingRappoMarkAddeds;
                    weavingRappoMarks.LstDataDelete = dbWeavingRappoMarkDeletes;
                    weavingRappoMatrics.LstDataUpdate = dbWeavingRappoMatricModifieds;
                    weavingRappoMatrics.LstDataAdd = newWeavingRappoMatricAddeds;
                    weavingRappoMatrics.LstDataDelete = dbWeavingRappoMatricDeletes;
                }
                else
                {
                    return new($"WeavingRappo Id Not Found.");
                }
            }
            else
            {
                request.WeavingRappo.WeavingRappoMatrics = request.WeavingRappo.WeavingRappoMatrics.Select(x =>
                {
                    x.Id = 0;
                    return x;
                });
                rappo = _mapper.Map<WeavingRappo>(request.WeavingRappo);
            }

            #endregion WeavingRappo

            #region WeavingRusticFabricSpec

            spec = await _weavingRusticFabricSpec.GetByIdAsync(request.WeavingRusticFabricSpec.Id);
            if (spec != null)
            {
                spec.WeavingIEDId = request.WeavingIEDId;
                spec.LineNumber = request.WeavingRusticFabricSpec.LineNumber;
                spec.ContentWeaveStyle = request.WeavingRusticFabricSpec.ContentWeaveStyle;
                spec.HarnessFrameCWS = request.WeavingRusticFabricSpec.HarnessFrameCWS;
                spec.MarginWeaveStyle = request.WeavingRusticFabricSpec.MarginWeaveStyle;
                spec.HarnessFrameMWS = request.WeavingRusticFabricSpec.HarnessFrameMWS;
                spec.WeightGM = request.WeavingRusticFabricSpec.WeightGM;
                spec.WeightGM2 = request.WeavingRusticFabricSpec.WeightGM2;
                spec.WarpShrinkage = request.WeavingRusticFabricSpec.WarpShrinkage;
                spec.WeftShrinkage = request.WeavingRusticFabricSpec.WeftShrinkage;
                spec.MachineType = request.WeavingRusticFabricSpec.MachineType;
                spec.RPM = request.WeavingRusticFabricSpec.RPM;
                spec.ReedCount = request.WeavingRusticFabricSpec.ReedCount;
                spec.ReedWidth = request.WeavingRusticFabricSpec.ReedWidth;
                spec.WarpDensity = request.WeavingRusticFabricSpec.WarpDensity;
                spec.WeftDensity = request.WeavingRusticFabricSpec.WeftDensity;
                spec.GreigeWidth = request.WeavingRusticFabricSpec.GreigeWidth;
                spec.SettingWeftDensity = request.WeavingRusticFabricSpec.SettingWeftDensity;
            }
            else
            {
                return new($"WeavingRusticFabricSpec Id Not Found.");
            }

            #endregion WeavingRusticFabricSpec

            #region WeavingDetailStructure

            var dataExistWeavingDetailStructure = await _weavingDetailStructure.GetAllByWeavingIEDId(request.WeavingIEDId);
            var dbWeavingDetailStructureModified = dataExistWeavingDetailStructure.Where(x => request.WeavingDetailStructures.Any(y => y.Id == x.Id)).Select(
                x =>
                {
                    var data = request.WeavingDetailStructures.FirstOrDefault(c => c.Id == x.Id);
                    x.Denting = data?.Denting ?? x.Denting;
                    x.DentSplit = data?.DentSplit ?? x.DentSplit;
                    x.Total = data?.Total ?? x.Total;
                    x.LineNumber = data?.LineNumber ?? x.LineNumber;
                    return x;
                });

            #endregion WeavingDetailStructure

            #region WeavingYarn

            var dataExistWeavingYarn = await _weavingYarn.GetAllByWeavingIEDId(request.WeavingIEDId);
            var dbWeavingYarnModified = dataExistWeavingYarn.Where(x => request.WeavingYarns.Any(y => y.Id == x.Id)).Select(
                x =>
                {
                    var data = request.WeavingYarns.FirstOrDefault(c => c.Id == x.Id);
                    x.LineNumber = data?.LineNumber ?? x.LineNumber;
                    x.ScaleRatio = data?.ScaleRatio ?? x.ScaleRatio;
                    x.ScrapRatio = data?.ScrapRatio ?? x.ScrapRatio;
                    x.SizingRatio = data?.SizingRatio ?? x.SizingRatio;
                    x.WastageRatio = data?.WastageRatio ?? x.WastageRatio;
                    x.YarnInRappo = data?.YarnInRappo ?? x.YarnInRappo;
                    x.YarnRatio = data?.YarnRatio ?? x.YarnRatio;
                    x.Weight = data?.Weight ?? x.Weight;
                    x.YarnTotal = data?.YarnTotal ?? x.YarnTotal;
                    return x;
                });

            #endregion WeavingYarn

            structures.LstDataUpdate = dbWeavingDetailStructureModified;
            structures.LstDataAdd = new List<WeavingDetailStructure>();
            structures.LstDataDelete = new List<WeavingDetailStructure>();
            weavingYarns.LstDataUpdate = dbWeavingYarnModified;
            weavingYarns.LstDataAdd = new List<WeavingYarn>();
            weavingYarns.LstDataDelete = new List<WeavingYarn>();

            await _weavingSpecification.AddWeavingRappoSpecificationAsync(weavingYarns, structures, spec, rappo, weavingRappoMarks, weavingRappoMatrics);
            return new Response<bool>(true);
        }
    }
}