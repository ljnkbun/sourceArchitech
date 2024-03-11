using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.WeavingOperationInputArticles;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingOperations
{
    public class CreateWeavingOperationCommand : IRequest<Response<int>>
    {
        public int WeavingRoutingId { get; set; }
        public int LineNumber { get; set; }
        public int OperationId { get; set; }
        public string Operation { get; set; }
        public string MachineType { get; set; }
        public int WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public ICollection<CreateWeavingOperationInputArticleCommand> WeavingOperationInputArticles { get; set; }
    }

    public class CreateWeavingOperationCommandHandler : IRequestHandler<CreateWeavingOperationCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingOperationRepository _repository;

        public CreateWeavingOperationCommandHandler(IMapper mapper,
            IWeavingOperationRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingOperationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingOperation>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}