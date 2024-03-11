using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.WeavingOperationInputArticles;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingOperations
{
    public class UpdateWeavingOperationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int WeavingRoutingId { get; set; }
        public int LineNumber { get; set; }
        public int OperationId { get; set; }
        public string Operation { get; set; }
        public string MachineType { get; set; }
        public int WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public bool IsActive { set; get; }
        public ICollection<UpdateWeavingOperationInputArticleCommand> WeavingOperationInputArticles { get; set; }
    }

    public class UpdateWeavingOperationCommandHandler : IRequestHandler<UpdateWeavingOperationCommand, Response<int>>
    {
        private readonly IWeavingOperationRepository _repository;
        private readonly IMapper _mapper;

        public UpdateWeavingOperationCommandHandler(IWeavingOperationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateWeavingOperationCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"WeavingOperation Not Found.");
            entity.ArticleName = command.ArticleName;
            entity.ArticleCode = command.ArticleCode;
            entity.LineNumber = command.LineNumber;
            entity.MachineType = command.MachineType;
            entity.Operation = command.Operation;
            entity.WFXArticleId = command.WFXArticleId;
            entity.WeavingRoutingId = command.WeavingRoutingId;
            entity.OperationId = command.OperationId;
            entity.IsActive = command.IsActive;
            var dbWeavingOperationInputArticles = entity.WeavingOperationInputArticles;
            entity.WeavingOperationInputArticles = null;

            #region WeavingOperationInputArticle

            var dbWeavingOperationInputArticleModifieds = dbWeavingOperationInputArticles.Where(x => command.WeavingOperationInputArticles.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(command.WeavingOperationInputArticles.First(c => c.Id == x.Id), x));

            var newWeavingOperationInputArticleAddeds = command.WeavingOperationInputArticles.Where(x => x.Id == 0)
                .Select(x => _mapper.Map<WeavingOperationInputArticle>(x));

            var dbWeavingOperationInputArticleDeletes =
                dbWeavingOperationInputArticles.Where(x => dbWeavingOperationInputArticleModifieds.All(y => y.Id != x.Id));

            #endregion WeavingOperationInputArticle

            await _repository.UpdateWeavingOperationAsync(entity, new BaseUpdateEntity<WeavingOperationInputArticle>
            {
                LstDataUpdate = dbWeavingOperationInputArticleModifieds,
                LstDataAdd = newWeavingOperationInputArticleAddeds,
                LstDataDelete = dbWeavingOperationInputArticleDeletes
            });
            return new Response<int>(entity.Id);
        }
    }
}