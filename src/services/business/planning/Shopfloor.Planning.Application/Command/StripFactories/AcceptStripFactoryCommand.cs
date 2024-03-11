using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactories
{
    public class AcceptStripFactoryCommand : IRequest<Response<bool>>
    {
        public List<int> Ids { get; set; }
    }
    public class AcceptStripFactoryCommandHandler : IRequestHandler<AcceptStripFactoryCommand, Response<bool>>
    {
        private readonly IStripFactoryRepository _repository;
        public AcceptStripFactoryCommandHandler(IStripFactoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(AcceptStripFactoryCommand command, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdsAsync(command.Ids);
            if (entities.Count == 0) return new($"StripFactories Not Found.");

            entities.ForEach(x => x.IsAllocated = true);
            await _repository.UpdateRangeAsync(entities);
            return new Response<bool>(true);
        }
    }
}
