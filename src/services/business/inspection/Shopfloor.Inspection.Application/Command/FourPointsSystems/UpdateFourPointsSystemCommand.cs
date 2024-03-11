using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.FourPointsSystems
{
    public class UpdateFourPointsSystemCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ProductGroup { get; set; }

        public bool IsActive { set; get; }
    }
    public class UpdateFourPointsSystemCommandHandler : IRequestHandler<UpdateFourPointsSystemCommand, Response<int>>
    {
        private readonly IFourPointsSystemRepository _repository;
        public UpdateFourPointsSystemCommandHandler(IFourPointsSystemRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateFourPointsSystemCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"FourPointsSystem Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;
            entity.ProductGroup = command.ProductGroup;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
