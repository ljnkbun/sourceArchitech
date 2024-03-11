using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.LiquorRatios
{
    public class UpdateLiquorRatioCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateLiquorRatioCommandHandler : IRequestHandler<UpdateLiquorRatioCommand, Response<int>>
    {
        private readonly ILiquorRatioRepository _repository;
        public UpdateLiquorRatioCommandHandler(ILiquorRatioRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateLiquorRatioCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"LiquorRatio Not Found.");

            entity.Value = command.Value;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
