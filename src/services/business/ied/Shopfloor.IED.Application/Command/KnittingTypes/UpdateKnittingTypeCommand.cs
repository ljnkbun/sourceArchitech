using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingTypes
{
    public class UpdateKnittingTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateKnittingTypeCommandHandler : IRequestHandler<UpdateKnittingTypeCommand, Response<int>>
    {
        private readonly IKnittingTypeRepository _repository;
        public UpdateKnittingTypeCommandHandler(IKnittingTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateKnittingTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"KnittingType Not Found.");

            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
