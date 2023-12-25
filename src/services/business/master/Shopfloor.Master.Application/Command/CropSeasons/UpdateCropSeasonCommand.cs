using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CropSeasons
{
    public class UpdateCropSeasonCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateCropSeasonCommandHandler : IRequestHandler<UpdateCropSeasonCommand, Response<int>>
    {
        private readonly ICropSeasonRepository _repository;
        public UpdateCropSeasonCommandHandler(ICropSeasonRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateCropSeasonCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"CropSeason Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
