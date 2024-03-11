using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.WfxGDIs;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.WfxGDIs
{
    public class GetWfxGDIByArticleCodeOrderRefQuery : IRequest<Response<WfxGDIMasterModel>>
    {
        public string WfxArticleCode { get; set; }
        public string OrderRefNum { get; set; }
        public string GDINum { get; set; }
    }
    public class GetWfxGDIByArticleCodeOrderRefQueryHandler : IRequestHandler<GetWfxGDIByArticleCodeOrderRefQuery, Response<WfxGDIMasterModel>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxGDIRepository _repository;
        public GetWfxGDIByArticleCodeOrderRefQueryHandler(IMapper mapper,
            IWfxGDIRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<WfxGDIMasterModel>> Handle(GetWfxGDIByArticleCodeOrderRefQuery query, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByArticleCodeOrderRefAsync(query.WfxArticleCode, query.GDINum, query.OrderRefNum ?? string.Empty);
            if (entities == null || !entities.Any()) return new($"Recipe Unit Not Found (WfxArticleCode:{query.WfxArticleCode}), OrderRefNum:{query.OrderRefNum}).");
            var master = _mapper.Map<List<WfxGDIMasterModel>>(entities);

            return new Response<WfxGDIMasterModel>(master.FirstOrDefault());
        }
    }
}
