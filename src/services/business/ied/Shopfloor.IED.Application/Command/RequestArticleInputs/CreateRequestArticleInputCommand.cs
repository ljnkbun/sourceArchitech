using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestArticleInputs
{
    public class CreateRequestArticleInputCommand : IRequest<Response<int>>
    {
        public int RequestArticleOutputId { get; set; }
        public int WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
    }
    public class CreateRequestArticleInputCommandHandler : IRequestHandler<CreateRequestArticleInputCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestArticleInputRepository _repository;
        public CreateRequestArticleInputCommandHandler(IMapper mapper,
            IRequestArticleInputRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRequestArticleInputCommand RequestArticleInput, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<RequestArticleInput>(RequestArticleInput);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
