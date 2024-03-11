using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.WfxGDNs;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.WfxGDNs
{
    public class GetWfxGDNByArticleCodeGDNNumQuery : IRequest<Response<WfxGDNParentModel>>
    {
        public string WfxArticleCode { get; set; }
        public string GDNNum { get; set; }
    }
    public class GetWfxGDNByArticleCodeGDNNumQueryHandler : IRequestHandler<GetWfxGDNByArticleCodeGDNNumQuery, Response<WfxGDNParentModel>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxGDNRepository _repository;
        public GetWfxGDNByArticleCodeGDNNumQueryHandler(IMapper mapper,
            IWfxGDNRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<WfxGDNParentModel>> Handle(GetWfxGDNByArticleCodeGDNNumQuery query, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByArticleCodeGDNNumAsync(query.WfxArticleCode, query.GDNNum ?? string.Empty);
            if (entities == null || !entities.Any()) return new($"Recipe Unit Not Found (WfxArticleCode:{query.WfxArticleCode}), GDNNum:{query.GDNNum}).");

            var master = _mapper.Map<List<WfxGDNMasterModel>>(entities);

            var articleModel = _mapper.Map<WfxGDNParentModel>(master.FirstOrDefault());
            articleModel.WfxGDNChildModels = _mapper.Map<List<WfxGDNChildModel>>(master);

            return new Response<WfxGDNParentModel>(articleModel);
        }
    }
}
