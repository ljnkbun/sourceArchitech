using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRappoMarks
{
    public class UpdateWeavingRappoMarkCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int ColumnNo { get; set; }
        public int PatternIndex { get; set; }
    }
    public class UpdateWeavingRappoMarkCommandHandler : IRequestHandler<UpdateWeavingRappoMarkCommand, Response<int>>
    {
        private readonly IWeavingRappoMarkRepository _repository;
        public UpdateWeavingRappoMarkCommandHandler(IWeavingRappoMarkRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingRappoMarkCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"WeavingRappoMark Not Found.");

            entity.ColumnNo = command.ColumnNo;
            entity.PatternIndex = command.PatternIndex;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
