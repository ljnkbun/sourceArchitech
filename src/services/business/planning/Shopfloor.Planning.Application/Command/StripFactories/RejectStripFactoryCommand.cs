using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactories
{
    public class RejectStripFactoryCommand : IRequest<Response<bool>>
    {
        public List<int> Ids { get; set; }
    }
    public class RejectStripFactoryCommandHandler : IRequestHandler<RejectStripFactoryCommand, Response<bool>>
    {
        private readonly IStripFactoryRepository _repository;
        public RejectStripFactoryCommandHandler(IStripFactoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(RejectStripFactoryCommand command, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetWithDetailByIdsAsync(command.Ids);
            if (entities.Count == 0) return new($"StripFactories Not Found.");

            await _repository.RejectStripFactoryAsync(entities);
            return new Response<bool>(true);
        }
    }
}
