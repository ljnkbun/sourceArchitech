using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Models.Inpection100PointSyss;
using Shopfloor.Inspection.Application.Models.QCDefinitions;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Query.Inpection100PointSyss
{
    public class GetInpection100PointSysQuery : IRequest<Response<Inpection100PointSysModel>>
    {
        public int Id { get; set; }
    }
    public class GetInpection100PointSysQueryHandler : IRequestHandler<GetInpection100PointSysQuery, Response<Inpection100PointSysModel>>
    {
        private readonly IInpection100PointSysRepository _repository;
        private readonly IQCDefinitionRepository _repositoryQCDefinition;
        private readonly IQCDefectRepository _repositoryQCDefect;
        private readonly IMapper _mapper;
        public GetInpection100PointSysQueryHandler(IMapper mapper,
            IInpection100PointSysRepository repository
            , IQCDefectRepository repositoryQCDefect
            , IQCDefinitionRepository repositoryQCDefinition)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryQCDefinition = repositoryQCDefinition;
            _repositoryQCDefect = repositoryQCDefect;
        }
        public async Task<Response<Inpection100PointSysModel>> Handle(GetInpection100PointSysQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetInpection100PointSysWithDetaiḷ(query.Id);
            if (entity == null) return new($"Inpection100PointSyss Not Found (Id:{query.Id}).");
            var inspection100PointSysModel = _mapper.Map<Inpection100PointSysModel>(entity);
            var qcDefinitionCode = inspection100PointSysModel.QCRequestArticle.QCRequest.QCDefinitionCode;
            var qcDefinition = await _repositoryQCDefinition.GetQCDefinitionByCode(qcDefinitionCode);
            var qcDefinitionModel = _mapper.Map<QCDefinitionModel>(qcDefinition);
            inspection100PointSysModel.QCDefinition = qcDefinitionModel;
            var qcDefectIds = entity.InspectionDefectCapturing100PointSyss.Select(x => x.QCDefectId).ToList();
            var qcDefectResult = await _repositoryQCDefect.GetByIdsAsync(qcDefectIds.ToArray());
            foreach (var item in inspection100PointSysModel.InspectionDefectCapturing100PointSyss)
            {
                var qcDefect = qcDefectResult.First(x => x.Id == item.QCDefectId);
                item.Level = qcDefect.Level;
                item.ParrentId = qcDefect.ParrentId;
                item.QCDefectNameEN = qcDefect.NameEN;
                item.QCDefectNameVN = qcDefect.Name;
                item.QCDefectCode = qcDefect.Code;
            }

            return new Response<Inpection100PointSysModel>(inspection100PointSysModel);
        }
    }
}
