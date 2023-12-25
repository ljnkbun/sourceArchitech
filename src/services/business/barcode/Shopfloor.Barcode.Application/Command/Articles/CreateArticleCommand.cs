using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Articles
{
    public class CreateArticleCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _repository;
        public CreateArticleCommandHandler(IMapper mapper,
            IArticleRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Article>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
