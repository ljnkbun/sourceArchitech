using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.WeavingOperations;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRoutings
{
    public class UpdateWeavingRoutingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public string WeavingProcess { get; set; }
        public string WeavingProcessCode { get; set; }
        public bool IsActive { set; get; }
        public ICollection<UpdateWeavingOperationCommand> WeavingOperations { get; set; }
    }

    public class UpdateWeavingRoutingCommandHandler : IRequestHandler<UpdateWeavingRoutingCommand, Response<int>>
    {
        private readonly IWeavingRoutingRepository _repository;
        private readonly IMapper _mapper;

        public UpdateWeavingRoutingCommandHandler(IWeavingRoutingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateWeavingRoutingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"WeavingRouting Not Found.");

            entity.LineNumber = command.LineNumber;
            entity.WeavingProcess = command.WeavingProcess;
            entity.IsActive = command.IsActive;
            entity.WeavingProcessCode = command.WeavingProcessCode;
            var dbWeavingOperationInputArticles = entity.WeavingOperations
             .SelectMany(x => x.WeavingOperationInputArticles).ToList();
            var dbWeavingOperations = entity.WeavingOperations.Select(x =>
            {
                x.WeavingOperationInputArticles = null;
                return x;
            }).ToList();

            var commandWeavingOperationInputArticles = command.WeavingOperations
                .SelectMany(x => x.WeavingOperationInputArticles).ToList();
            var commandWeavingOperations = command.WeavingOperations.ToList();
            entity.WeavingOperations = null;

            #region WeavingOperation

            var dbWeavingOperationModifieds = dbWeavingOperations.Where(x => commandWeavingOperations.Any(y => y.Id == x.Id)).Select(
                x =>
                {
                    var data = _mapper.Map(commandWeavingOperations.First(c => c.Id == x.Id), x);
                    data.WeavingOperationInputArticles = null;
                    return data;
                });

            var newWeavingOperationAddeds = commandWeavingOperations.Where(x => x.Id == 0 && x.WeavingRoutingId != 0)
                .Select(x => _mapper.Map<WeavingOperation>(x));

            var dbWeavingOperationDeletes =
                dbWeavingOperations.Where(x => dbWeavingOperationModifieds.All(y => y.Id != x.Id));

            #endregion WeavingOperation

            #region WeavingOperationInputArticle

            var dbWeavingOperationInputArticleModifieds = dbWeavingOperationInputArticles.Where(x => commandWeavingOperationInputArticles.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(commandWeavingOperationInputArticles.First(c => c.Id == x.Id), x));

            var newWeavingOperationInputArticleAddeds = commandWeavingOperationInputArticles.Where(x => x.Id == 0 && x.WeavingOperationId != 0)
                .Select(x => _mapper.Map<WeavingOperationInputArticle>(x));

            var dbWeavingOperationInputArticleDeletes =
                dbWeavingOperationInputArticles.Where(x => dbWeavingOperationInputArticleModifieds.All(y => y.Id != x.Id));

            #endregion WeavingOperationInputArticle

            await _repository.UpdateWeavingRoutingAsync(entity, new BaseUpdateEntity<WeavingOperation>
            {
                LstDataUpdate = dbWeavingOperationModifieds,
                LstDataAdd = newWeavingOperationAddeds,
                LstDataDelete = dbWeavingOperationDeletes
            }, new BaseUpdateEntity<WeavingOperationInputArticle>
            {
                LstDataUpdate = dbWeavingOperationInputArticleModifieds,
                LstDataAdd = newWeavingOperationInputArticleAddeds,
                LstDataDelete = dbWeavingOperationInputArticleDeletes
            });
            return new Response<int>(entity.Id);
        }
    }
}