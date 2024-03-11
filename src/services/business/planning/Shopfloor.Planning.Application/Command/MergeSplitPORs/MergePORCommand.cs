using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.MergeSplitPORs
{
    public class MergePORCommand : IRequest<Response<POR>>
    {
        public string PORIds { get; set; }
    }

    public class MergePORCommandHandler : IRequestHandler<MergePORCommand, Response<POR>>
    {
        private IPORRepository _wfxPORRepository;
        public MergePORCommandHandler(IPORRepository wfxPORRepository)
        {
            _wfxPORRepository = wfxPORRepository;
        }

        public async Task<Response<POR>> Handle(MergePORCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(command.PORIds)) return new($"POR Not Found.");
            var ids = command.PORIds.Split(",").Select(int.Parse).ToList();

            var entities = await _wfxPORRepository.GetWfxPORByIdsAsync(ids);
            var entityFirst = entities.FirstOrDefault();

            if (!entities.TrueForAll(x => x.ProcessName.Equals(entityFirst.ProcessName)))
                return new($"Process Not Match.");

            var result = await _wfxPORRepository.MergePORAsync(entities);

            return new Response<POR>(result);
        }
    }
}
