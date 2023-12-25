using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.RequestArticleInputs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestArticleOutputs
{
    public class CreateRequestArticleOutputCommand : IRequest<Response<int>>
    {
        public int RequestDivisionProcessId { get; set; }
        public int ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Color { get; set; }
        public ICollection<CreateRequestArticleInputCommand> RequestArticleInputs { get; set; }
    }
    public class CreateRequestArticleOutputCommandHandler : IRequestHandler<CreateRequestArticleOutputCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestArticleOutputRepository _repository;
        public CreateRequestArticleOutputCommandHandler(IMapper mapper,
            IRequestArticleOutputRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRequestArticleOutputCommand RequestArticleOutput, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<RequestArticleOutput>(RequestArticleOutput);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
