using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingBodyTypes
{
    public class UpdateKnittingBodyTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateKnittingBodyTypeCommandHandler : IRequestHandler<UpdateKnittingBodyTypeCommand, Response<int>>
    {
        private readonly IKnittingBodyTypeRepository _repository;
        public UpdateKnittingBodyTypeCommandHandler(IKnittingBodyTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateKnittingBodyTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"KnittingBodyType Not Found.");

            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
