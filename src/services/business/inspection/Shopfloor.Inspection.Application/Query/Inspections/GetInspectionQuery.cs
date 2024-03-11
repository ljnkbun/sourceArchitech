using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Models.Inspections;
using Shopfloor.Inspection.Application.Models.QCDefinitions;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Query.Inspections
{
    public class GetInspectionQuery : IRequest<Response<InspectionModel>>
    {
        public int Id { get; set; }
    }
    public class GetInspectionQueryHandler : IRequestHandler<GetInspectionQuery, Response<InspectionModel>>
    {
        private readonly IInspectionRepository _repository;
        private readonly IQCDefinitionRepository _repositoryQCDefinition;
        private readonly IQCDefectRepository _repositoryQCDefect;
        private readonly IMapper _mapper;
        public GetInspectionQueryHandler(IMapper mapper
            , IInspectionRepository repository
            , IQCDefectRepository repositoryQCDefect
            , IQCDefinitionRepository repositoryQCDefinition)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryQCDefinition = repositoryQCDefinition;
            _repositoryQCDefect = repositoryQCDefect;
        }
        public async Task<Response<InspectionModel>> Handle(GetInspectionQuery query, CancellationToken cancellationToken)
        {
            var inspection = await _repository.GetInspectionWithDetaiḷ(query.Id);
            if (inspection == null) return new($"Inspections Not Found (Id:{query.Id}).");
            var inspectionModel = _mapper.Map<InspectionModel>(inspection);
            var qcDefinitionCode = inspectionModel.QCRequestArticle.QCRequest.QCDefinitionCode;
            var qcDefinition = await _repositoryQCDefinition.GetQCDefinitionByCode(qcDefinitionCode);
            var qcDefinitionModel = _mapper.Map<QCDefinitionModel>(qcDefinition);
            inspectionModel.QCDefinition = qcDefinitionModel;
            var qcDefectIds = inspection.InspectionDefectCapturings.Select(x => x.QCDefectId).ToList();
            var mesureMentIds = inspection.InspectionMesurements.Select(x => x.QCDefectId).ToList();
            var ids = qcDefectIds.Concat(mesureMentIds);
            var qcDefectResult = await _repositoryQCDefect.GetByIdsAsync(ids.ToArray());
            foreach (var item in inspectionModel.InspectionDefectCapturings)
            {
                var qcDefect = qcDefectResult.First(x => x.Id == item.QCDefectId);
                item.Level = qcDefect.Level;
                item.ParrentId = qcDefect.ParrentId;
                item.QCDefectNameEN = qcDefect.NameEN;
                item.QCDefectNameVN = qcDefect.Name;
                item.QCDefectCode = qcDefect.Code;
            }

            foreach (var item in inspectionModel.InspectionMesurements)
            {
                var mesurement = qcDefectResult.First(x => x.Id == item.QCDefectId);
                item.Level = mesurement.Level;
                item.ParrentId = mesurement.ParrentId;
                item.QCDefectNameEN = mesurement.NameEN;
                item.QCDefectNameVN = mesurement.Name;
                item.QCDefectCode = mesurement.Code;
            }
            return new Response<InspectionModel>(inspectionModel);
        }
    }
}
