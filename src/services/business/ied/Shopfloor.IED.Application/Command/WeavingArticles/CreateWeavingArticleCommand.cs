using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingArticles
{
    public class CreateWeavingArticleCommand : IRequest<Response<int>>
    {
        public int WeavingIEDId { get; set; }
        public int ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
    }
    public class CreateWeavingArticleCommandHandler : IRequestHandler<CreateWeavingArticleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingArticleRepository _repository;
        public CreateWeavingArticleCommandHandler(IMapper mapper,
            IWeavingArticleRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingArticleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingArticle>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
