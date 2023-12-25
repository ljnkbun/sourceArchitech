using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CropSeasons
{
    public class DeleteCropSeasonCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCropSeasonCommandHandler : IRequestHandler<DeleteCropSeasonCommand, Response<int>>
    {
        private readonly ICropSeasonRepository _repository;
        public DeleteCropSeasonCommandHandler(ICropSeasonRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteCropSeasonCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"CropSeason Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
