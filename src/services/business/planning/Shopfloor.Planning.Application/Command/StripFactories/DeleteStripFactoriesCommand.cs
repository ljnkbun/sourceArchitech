using MediatR;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactories
{
    public class DeleteStripFactoriesCommand : IRequest<Response<bool>>
    {
        public List<int> Ids { get; set; }
    }
    public class DeleteStripFactoriesCommandHandler : IRequestHandler<DeleteStripFactoriesCommand, Response<bool>>
    {
        private readonly IStripFactoryRepository _repository;
        public DeleteStripFactoriesCommandHandler(IStripFactoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(DeleteStripFactoriesCommand command, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdsAsync(command.Ids);
            if (entities.Count == 0) return new($"StripFactories Not Found (Id:{command.Ids.ToJson()}).");
            if (entities.Any(x => x.IsAllocated == true)) 
                return new($"StripFactory Is Allocated, Cannot delete (Id:{entities.First(x => x.IsAllocated == true).Id}).");
            await _repository.DeleteRangeAsync(entities);
            return new Response<bool>(true);
        }
    }
}
