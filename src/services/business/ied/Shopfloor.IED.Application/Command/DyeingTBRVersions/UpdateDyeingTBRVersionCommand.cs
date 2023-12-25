using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRVersions
{
    public class UpdateDyeingTBRVersionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int DyeingTBRecipeId { get; set; }

        public int Version { get; set; }

        public DateTime DoTime { get; set; }

        public bool Approved { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateDyeingTBRVersionCommandHandler : IRequestHandler<UpdateDyeingTBRVersionCommand, Response<int>>
    {
        private readonly IDyeingTBRVersionRepository _repository;

        public UpdateDyeingTBRVersionCommandHandler(IDyeingTBRVersionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBRVersionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"DyeingTBRVersion Not Found.");

            entity.DyeingTBRecipeId = command.DyeingTBRecipeId;
            entity.Version = command.Version;
            entity.DoTime = command.DoTime;
            entity.Approved = command.Approved;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}