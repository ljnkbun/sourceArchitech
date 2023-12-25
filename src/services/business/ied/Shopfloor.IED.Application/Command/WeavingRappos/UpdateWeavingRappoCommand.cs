using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRappos
{
    public class UpdateWeavingRappoCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int NumOfLine { get; set; }
        public int YarnOfBorder { get; set; }
        public int YarnOfBackground { get; set; }
        public int NumOfRappo { get; set; }
        public string VerticalRappoComment { get; set; }
        public string HorizontalRappoComment { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateWeavingRappoCommandHandler : IRequestHandler<UpdateWeavingRappoCommand, Response<int>>
    {
        private readonly IWeavingRappoRepository _repository;
        public UpdateWeavingRappoCommandHandler(IWeavingRappoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingRappoCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"WeavingRappo Not Found.");

            entity.NumOfLine = command.NumOfLine;
            entity.YarnOfBorder = command.YarnOfBorder;
            entity.YarnOfBackground = command.YarnOfBackground;
            entity.NumOfRappo = command.NumOfRappo;
            entity.VerticalRappoComment = command.VerticalRappoComment;
            entity.HorizontalRappoComment = command.HorizontalRappoComment;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
