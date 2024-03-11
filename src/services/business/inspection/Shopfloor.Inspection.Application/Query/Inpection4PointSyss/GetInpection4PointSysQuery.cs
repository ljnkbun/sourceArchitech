using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Models.Inpection4PointSyss;
using Shopfloor.Inspection.Application.Models.QCDefinitions;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Query.Inpection4PointSyss
{
    public class GetInpection4PointSysQuery : IRequest<Response<Inpection4PointSysModel>>
    {
        public int Id { get; set; }
    }
    public class GetInpection4PointSysQueryHandler : IRequestHandler<GetInpection4PointSysQuery, Response<Inpection4PointSysModel>>
    {
        private readonly IInpection4PointSysRepository _repository;
        private readonly IQCDefinitionRepository _repositoryQCDefinition;
        private readonly IQCDefectRepository _repositoryQCDefect;
        private readonly IMapper _mapper;
        public GetInpection4PointSysQueryHandler(IMapper mapper, IInpection4PointSysRepository repository
            , IQCDefectRepository repositoryQCDefect
            , IQCDefinitionRepository repositoryQCDefinition)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryQCDefinition = repositoryQCDefinition;
            _repositoryQCDefect = repositoryQCDefect;
        }
        public async Task<Response<Inpection4PointSysModel>> Handle(GetInpection4PointSysQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetInpection4PointSysWithDetaiḷ(query.Id);
            if (entity == null) return new($"Inpection4PointSyss Not Found (Id:{query.Id}).");
            var inpection4PointSysModel = _mapper.Map<Inpection4PointSysModel>(entity);
            var qcDefinitionCode = inpection4PointSysModel.QCRequestArticle.QCRequest.QCDefinitionCode;
            var qcDefinition = await _repositoryQCDefinition.GetQCDefinitionByCode(qcDefinitionCode);
            var qcDefinitionModel = _mapper.Map<QCDefinitionModel>(qcDefinition);
            inpection4PointSysModel.QCDefinition = qcDefinitionModel;
            var qcDefectIds = entity.InspectionDefectCapturing4PointSyss.Select(x => x.QCDefectId).ToList();
            var qcDefectResult = await _repositoryQCDefect.GetByIdsAsync(qcDefectIds.ToArray());
            foreach (var item in inpection4PointSysModel.InspectionDefectCapturing4PointSyss)
            {
                var qcDefect = qcDefectResult.First(x => x.Id == item.QCDefectId);
                item.Level = qcDefect.Level;
                item.ParrentId = qcDefect.ParrentId;
                item.QCDefectNameEN = qcDefect.NameEN;
                item.QCDefectNameVN = qcDefect.Name;
                item.QCDefectCode = qcDefect.Code;
            }
            return new Response<Inpection4PointSysModel>(inpection4PointSysModel);
        }
    }
}
