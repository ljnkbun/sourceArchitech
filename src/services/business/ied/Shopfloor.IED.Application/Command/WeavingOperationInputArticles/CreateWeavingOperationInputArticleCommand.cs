using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingOperationInputArticles
{
    public class CreateWeavingOperationInputArticleCommand : IRequest<Response<int>>
    {
        public int WeavingOperationId { get; set; }
        public int WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
    }

    public class CreateWeavingOperationInputArticleCommandHandler : IRequestHandler<CreateWeavingOperationInputArticleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingOperationInputArticleRepository _repository;

        public CreateWeavingOperationInputArticleCommandHandler(IMapper mapper,
            IWeavingOperationInputArticleRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingOperationInputArticleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingOperationInputArticle>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}