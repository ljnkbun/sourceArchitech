using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests.ProductionOutputs;
using Shopfloor.EventBus.Models.Responses.ProductionOutputs;
using Shopfloor.EventBus.Services;
using Shopfloor.Inspection.Application.Models.InspectionBySizes;
using Shopfloor.Inspection.Application.Models.InspectionDefectCapturings;
using Shopfloor.Inspection.Application.Models.InspectionMesurements;
using Shopfloor.Inspection.Application.Models.Inspections;
using Shopfloor.Inspection.Application.Models.QCDefinitions;
using Shopfloor.Inspection.Application.Models.QCRequestArticles;
using Shopfloor.Inspection.Domain.Enums;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Query.QCRequestArticles
{
    public class GetQCRequestArticleQuery : IRequest<Response<QCRequestArticleModel>>
    {
        public int Id { get; set; }
    }
    public class GetQCRequestArticleQueryHandler : IRequestHandler<GetQCRequestArticleQuery, Response<QCRequestArticleModel>>
    {
        private readonly IQCRequestArticleRepository _repositoryQCRequestArticle;
        private readonly IQCRequestRepository _repositoryQCRequest;
        private readonly IInspectionRepository _repositoryInspection;
        private readonly IConversionRepository _repositoryConversion;
        private readonly IQCDefinitionRepository _repositoryQCDefinition;
        private readonly IQCDefectRepository _repositoryQCDefect;
        private readonly IRequestClientService _requestClientService;
        private readonly IMapper _mapper;
        public GetQCRequestArticleQueryHandler(IMapper mapper
            , IQCRequestRepository repositoryQCRequest
            , IQCRequestArticleRepository repositoryQCRequestArticle
            , IInspectionRepository repositoryInspection
            , IConversionRepository repositoryConversion
            , IQCDefinitionRepository repositoryQCDefinition
            , IQCDefectRepository repositoryQCDefect
            , IRequestClientService requestClientService)
        {
            _repositoryQCRequest = repositoryQCRequest;
            _repositoryQCRequestArticle = repositoryQCRequestArticle;
            _mapper = mapper;
            _repositoryInspection = repositoryInspection;
            _repositoryConversion = repositoryConversion;
            _repositoryQCDefinition = repositoryQCDefinition;
            _repositoryQCDefect = repositoryQCDefect;
            _requestClientService = requestClientService;
        }

        public async Task<Response<QCRequestArticleModel>> Handle(GetQCRequestArticleQuery query, CancellationToken cancellationToken)
        {

            var existedQCResult = await _repositoryInspection.CheckExistInspectionByQCRequestArticleIIdAsync(query.Id);
            if (existedQCResult)
            {
                return await GetQCResult(query.Id);
            }
            //var qcResultFromProductionOutput = await GetQCResultFromProductionOutput(query.Id);
            return  await InitQCResult(query.Id) ;

        }
        private async Task<Response<QCRequestArticleModel>> InitQCResult(int id)
        {
            var entity = await _repositoryQCRequestArticle.GetQCRequestArticleByIdAsync(id);
            var qCRequestArticleModel = _mapper.Map<QCRequestArticleModel>(entity);
            var qcRequest = await _repositoryQCRequest.GetByIdAsync(entity.QCRequestId);
            var qcDefinition = await _repositoryQCDefinition.GetQCDefinitionByCode(qcRequest.QCDefinitionCode);
            var qcDefinitionModel = _mapper.Map<QCDefinitionModel>(qcDefinition);
            qCRequestArticleModel.ConversionVal = qcDefinition.Conversion.Value;
            qCRequestArticleModel.QCDefinitionCode = qcRequest.QCDefinitionCode;
            qCRequestArticleModel.QCDefinition = qcDefinitionModel;
            var qcDefects = qcDefinition.QCDefinitionDefects.Select(x => x.QCDefect);
            var defectCapturings = qcDefects.Where(x => x.InspectionType == InspectionType.Defect);
            var mesurement = qcDefects.Where(x => x.InspectionType == InspectionType.Mesurement);
            var articles = await _repositoryQCRequestArticle.GetQCRequestArticleByArticleCodeAsync(entity.ArticleCode);
            qCRequestArticleModel.InspectionModel = new InspectionModel()
            {
                QCRequestArticleId = id,
                InspectionBySizes = articles.Select(x => new InspectionBySizeModel()
                {
                    SizeCode = x.SizeCode,
                    SizeName = x.SizeName,
                    ColorCode = x.ColorCode,
                    ColorName = x.ColorName,
                }).ToList(),
                InspectionDefectCapturings = defectCapturings.Select(x => new InspectionDefectCapturingModel()
                {
                    QCDefectCode = x.Code,
                    QCDefectNameVN = x.Name,
                    QCDefectNameEN = x.NameEN,
                    ParrentId = x.ParrentId,
                    Level = x.Level,
                    QCDefectId = x.Id
                }).ToList(),
                InspectionMesurements = mesurement.Select(x => new InspectionMesurementModel()
                {
                    QCDefectCode = x.Code,
                    QCDefectNameVN = x.Name,
                    QCDefectNameEN = x.NameEN,
                    ParrentId = x.ParrentId,
                    Level = x.Level,
                    QCDefectId = x.Id
                }).ToList()
            };
            return new Response<QCRequestArticleModel>(qCRequestArticleModel);
        }
        private async Task<Response<QCRequestArticleModel>> GetQCResult(int id)
        {
            var entity = await _repositoryQCRequestArticle.GetQCRequesArticletWithInspectionByIdAsync(id);
            var qcDefectIds = entity.Inspection.InspectionDefectCapturings.Select(x => x.QCDefectId).ToList();
            var mesureMentIds = entity.Inspection.InspectionMesurements.Select(x => x.QCDefectId).ToList();
            var ids = qcDefectIds.Concat(mesureMentIds);
            var qCRequestArticleModel = _mapper.Map<QCRequestArticleModel>(entity);
            var qcDefectResult = await _repositoryQCDefect.GetByIdsAsync(ids.ToArray());
            var qcRequest = await _repositoryQCRequest.GetByIdAsync(entity.QCRequestId);
            var qcDefinition = await _repositoryQCDefinition.GetQCDefinitionByCode(qcRequest.QCDefinitionCode);
            qCRequestArticleModel.ConversionVal = qcDefinition.Conversion.Value;
            qCRequestArticleModel.QCDefinitionCode = qcRequest.QCDefinitionCode;
            var qcDefinitionModel= _mapper.Map<QCDefinitionModel>(qcDefinition);
            var inspectionModel = _mapper.Map<InspectionModel>(entity.Inspection);
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
            qCRequestArticleModel.InspectionModel = inspectionModel;
            return new Response<QCRequestArticleModel>(qCRequestArticleModel);
        }
        private async Task<Response<QCRequestArticleModel>> GetQCResultFromProductionOutput(int id)
        {
            var entity = await _repositoryQCRequestArticle.GetQCRequesArticletWithInspectionByIdAsync(id);
            QCRequestArticleModel qCRequestArticleModel = null;
            var qcRequest = await _repositoryQCRequest.GetByIdAsync(entity.QCRequestId);
            var qcResult = await _requestClientService.GetResponseAsync<GetGRNDetailByCodeRequest, GetGRNDetailByCodeResponse>(new GetGRNDetailByCodeRequest
            {
                Code = qcRequest.DocumentNo
            });
            if (qcResult.Message == null || qcResult.Message.InspectionBySizes.Count == 0)
            {
                return new Response<QCRequestArticleModel>(qCRequestArticleModel);
            }
            qCRequestArticleModel = _mapper.Map<QCRequestArticleModel>(entity);
            var qcDefinition = await _repositoryQCDefinition.GetQCDefinitionByCode(qcRequest.QCDefinitionCode);
            var qcDefinitionModel = _mapper.Map<QCDefinitionModel>(qcDefinition);
            var qcDefectIds = qcResult.Message.DefectCapturings.Select(x => x.QCDefinitionDefectId).ToList();
            var mesureMentIds = qcResult.Message.Mesurements.Select(x => x.QCDefinitionDefectId).ToList();
            var ids = qcDefectIds.Concat(mesureMentIds);
            var qcDefectResult = await _repositoryQCDefect.GetByIdsAsync(ids.ToArray());
            qCRequestArticleModel.ConversionVal = qcDefinition.Conversion.Value;
            qCRequestArticleModel.QCDefinitionCode = qcRequest.QCDefinitionCode;
            qCRequestArticleModel.QCDefinition = qcDefinitionModel;
            qCRequestArticleModel.InspectionModel = new InspectionModel()
            {
                IsCreatedFromProduction = true,
                QCRequestArticleId = id,
                InspectionBySizes = qcResult.Message.InspectionBySizes.Select(x => new InspectionBySizeModel()
                {
                    SizeCode = x.SizeCode,
                    SizeName = x.SizeName,
                    ColorCode = x.ColorCode,
                    ColorName = x.ColorName,
                    Shade = x.Shade,
                    Lot = x.Lot,
                    GRNQty = x.GRNQty,
                    PreInspectedQty = x.PreInspectedQty,
                    LotQty = x.LotQty,
                    InspectionQty = x.InspectionQty,
                    ActualQty = x.ActualQty,
                    NoOfDefect = x.NoOfDefect,
                    OKQty = x.OKQty,
                    BGroupQty = x.BGroupQty,
                    BGroupUsable = x.BGroupUsable,
                    RejectedQty = x.RejectedQty,
                    ExcessShortageQty = x.ExcessShortageQty,
                    ReasonforBGroup = x.ReasonforBGroup,
                }).ToList(),
                InspectionDefectCapturings = qcResult.Message.DefectCapturings.Select(x => new InspectionDefectCapturingModel()
                {
                    Minor = x.Minor,
                    Major = x.Major,
                    Critial = x.Critial,
                    ProblemRootCauseId = x.ProblemRootCauseId,
                    ProblemCorrectiveActionId = x.ProblemCorrectiveActionId,
                    ProblemTimelineId = x.ProblemTimelineId,
                    PersonInChargeId = x.PersonInChargeId,
                    QCDefectId = x.QCDefinitionDefectId,
                }).ToList(),
                InspectionMesurements = qcResult.Message.DefectCapturings.Select(x => new InspectionMesurementModel()
                {
                    Minor = x.Minor,
                    Major = x.Major,
                    Critial = x.Critial,
                    ProblemRootCauseId = x.ProblemRootCauseId,
                    ProblemCorrectiveActionId = x.ProblemCorrectiveActionId,
                    ProblemTimelineId = x.ProblemTimelineId,
                    PersonInChargeId = x.PersonInChargeId,
                    QCDefectId = x.QCDefinitionDefectId,
                }).ToList()
            };
            foreach (var item in qCRequestArticleModel.InspectionModel.InspectionDefectCapturings)
            {
                var qcDefect = qcDefectResult.First(x => x.Id == item.QCDefectId);
                item.Level = qcDefect.Level;
                item.ParrentId = qcDefect.ParrentId;
                item.QCDefectNameEN = qcDefect.NameEN;
                item.QCDefectNameVN = qcDefect.Name;
                item.QCDefectCode = qcDefect.Code;
            }

            foreach (var item in qCRequestArticleModel.InspectionModel.InspectionMesurements)
            {
                var qcDefect = qcDefectResult.First(x => x.Id == item.QCDefectId);
                item.Level = qcDefect.Level;
                item.ParrentId = qcDefect.ParrentId;
                item.QCDefectNameEN = qcDefect.NameEN;
                item.QCDefectNameVN = qcDefect.Name;
                item.QCDefectCode = qcDefect.Code;
            }
            return new Response<QCRequestArticleModel>(qCRequestArticleModel);
        }
    }
}
