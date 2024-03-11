using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingDetailStructures;
using Shopfloor.IED.Application.Models.WeavingRusticFabricSpecs;
using Shopfloor.IED.Application.Models.WeavingYarns;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingSpecifications
{
    public class CreateWeavingSpecificationCommand : IRequest<Response<bool>>
    {
        public int WeavingIEDId { get; set; }
        public IEnumerable<UpdateCreateWeavingYarnModel> WeavingYarns { get; set; }
        public UpdateCreateWeavingRusticFabricSpec WeavingRusticFabricSpec { get; set; }
        public IEnumerable<UpdateCreateWeavingDetailStructure> WeavingDetailStructures { get; set; }
    }

    public class CreateWeavingSpecificationCommandHandler : IRequestHandler<CreateWeavingSpecificationCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingSpecificationRepository _weavingSpecification;
        private readonly IWeavingYarnRepository _weavingYarn;
        private readonly IWeavingDetailStructureRepository _weavingDetailStructure;
        private readonly IWeavingRusticFabricSpecRepository _weavingRusticFabricSpec;
        private readonly IWeavingRappoRepository _weavingRappo;

        public CreateWeavingSpecificationCommandHandler(IMapper mapper,
            IWeavingSpecificationRepository weavingSpecification, IWeavingYarnRepository weavingYarn, IWeavingDetailStructureRepository weavingDetailStructure, IWeavingRusticFabricSpecRepository weavingRusticFabricSpec, IWeavingRappoRepository weavingRappo)
        {
            _weavingSpecification = weavingSpecification;
            _weavingYarn = weavingYarn;
            _weavingDetailStructure = weavingDetailStructure;
            _weavingRusticFabricSpec = weavingRusticFabricSpec;
            _weavingRappo = weavingRappo;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateWeavingSpecificationCommand request, CancellationToken cancellationToken)
        {
            WeavingRusticFabricSpec spec;
            var structures = new BaseUpdateEntity<WeavingDetailStructure>();
            var weavingYarns = new BaseUpdateEntity<WeavingYarn>();

            #region WeavingRusticFabricSpec

            if (request.WeavingRusticFabricSpec.Id != 0)
            {
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
            }
            else
            {
                spec = _mapper.Map<WeavingRusticFabricSpec>(request.WeavingRusticFabricSpec);
            }

            #endregion WeavingRusticFabricSpec

            #region WeavingDetailStructure

            var dataExistWeavingDetailStructure = await _weavingDetailStructure.GetAllByWeavingIEDId(request.WeavingIEDId);
            var dbWeavingDetailStructureModified = dataExistWeavingDetailStructure.Where(x => request.WeavingDetailStructures.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(request.WeavingDetailStructures.First(c => c.Id == x.Id), x));
            var newWeavingDetailStructureAdded = request.WeavingDetailStructures.Where(x => x.Id == 0)
                .Select(x => _mapper.Map<WeavingDetailStructure>(x));
            var dbWeavingDetailStructureDelete =
                dataExistWeavingDetailStructure.Where(x => dbWeavingDetailStructureModified.All(y => y.Id != x.Id));

            #endregion WeavingDetailStructure

            #region WeavingYarn

            var dataExistWeavingYarn = await _weavingYarn.GetAllByWeavingIEDId(request.WeavingIEDId);
            var dbWeavingYarnModified = dataExistWeavingYarn.Where(x => request.WeavingYarns.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(request.WeavingYarns.First(c => c.Id == x.Id), x));
            var newWeavingYarnAdded = request.WeavingYarns.Where(x => x.Id <= 0)
                .Select(x =>
                {
                    var rs = _mapper.Map<WeavingYarn>(x);
                    rs.Id = 0;
                    return rs;
                });
            var dbWeavingYarnDelete =
                dataExistWeavingYarn.Where(x => dbWeavingYarnModified.All(y => y.Id != x.Id));

            #endregion WeavingYarn

            structures.LstDataAdd = newWeavingDetailStructureAdded;
            structures.LstDataDelete = dbWeavingDetailStructureDelete;
            structures.LstDataUpdate = dbWeavingDetailStructureModified;
            weavingYarns.LstDataAdd = newWeavingYarnAdded;
            weavingYarns.LstDataDelete = dbWeavingYarnDelete;
            weavingYarns.LstDataUpdate = dbWeavingYarnModified;

            await _weavingSpecification.AddWeavingSpecificationAsync(weavingYarns, structures, spec);
            return new Response<bool>(true);
        }
    }
}