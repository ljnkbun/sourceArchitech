using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Models.InpectionTCStandards;
using Shopfloor.Inspection.Application.Models.QCDefinitions;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Query.InpectionTCStandards
{
    public class GetInpectionTCStandardQuery : IRequest<Response<InpectionTCStandardModel>>
    {
        public int Id { get; set; }
    }
    public class GetInpectionTCStandardQueryHandler : IRequestHandler<GetInpectionTCStandardQuery, Response<InpectionTCStandardModel>>
    {
        private readonly IInpectionTCStandardRepository _repository;
        private readonly IQCDefinitionRepository _repositoryQCDefinition;
        private readonly IQCDefectRepository _repositoryQCDefect;
        private readonly IMapper _mapper;
        public GetInpectionTCStandardQueryHandler(IMapper mapper, IInpectionTCStandardRepository repository
         , IQCDefectRepository repositoryQCDefect
            , IQCDefinitionRepository repositoryQCDefinition)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryQCDefinition = repositoryQCDefinition;
            _repositoryQCDefect = repositoryQCDefect;
        }
        public async Task<Response<InpectionTCStandardModel>> Handle(GetInpectionTCStandardQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"InpectionTCStandards Not Found (Id:{query.Id}).");
            var inpectionTCStandardModel = _mapper.Map<InpectionTCStandardModel>(entity);
            var qcDefinitionCode = inpectionTCStandardModel.QCRequestArticle.QCRequest.QCDefinitionCode;
            var qcDefinition = await _repositoryQCDefinition.GetQCDefinitionByCode(qcDefinitionCode);
            var qcDefinitionModel = _mapper.Map<QCDefinitionModel>(qcDefinition);
            inpectionTCStandardModel.QCDefinition = qcDefinitionModel;
            var qcDefectIds = entity.InspectionDefectCapturingTCStandards.Select(x => x.QCDefectId).ToList();
            var qcDefectResult = await _repositoryQCDefect.GetByIdsAsync(qcDefectIds.ToArray());
            foreach (var item in inpectionTCStandardModel.InspectionDefectCapturingTCStandards)
            {
                var qcDefect = qcDefectResult.First(x => x.Id == item.QCDefectId);
                item.Level = qcDefect.Level;
                item.ParrentId = qcDefect.ParrentId;
                item.QCDefectNameEN = qcDefect.NameEN;
                item.QCDefectNameVN = qcDefect.Name;
                item.QCDefectCode = qcDefect.Code;
            }
            return new Response<InpectionTCStandardModel>(inpectionTCStandardModel);
        }
    }
}
