using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.WfxPOArticles
{
    public class SaveWfxPOArticlesSyncCommand : IRequest<Response<bool>>
    {
        public ICollection<WfxPOArticle> Data { get; set; }
    }
    public class SaveWfxPOArticlesSyncCommandHandler : IRequestHandler<SaveWfxPOArticlesSyncCommand, Response<bool>>
    {
        private readonly IWfxPOArticleRepository _repository;
        public SaveWfxPOArticlesSyncCommandHandler(
            IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            _repository = scope.ServiceProvider.GetRequiredService<IWfxPOArticleRepository>();
        }

        public async Task<Response<bool>> Handle(SaveWfxPOArticlesSyncCommand request, CancellationToken cancellationToken)
        {
            var entities = request.Data;
            await _repository.SaveWfxPOArticleSync(entities.ToList());
            return new Response<bool>(true);
        }
    }
}
