using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.QCTypes
{
    public class UpdateQCTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public QCScreenType QCScreenType { get; set; }

        public bool IsActive { set; get; }
    }
    public class UpdateQCTypeCommandHandler : IRequestHandler<UpdateQCTypeCommand, Response<int>>
    {
        private readonly IQCTypeRepository _repository;
        public UpdateQCTypeCommandHandler(IQCTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateQCTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new ($"QCType Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;
            entity.QCScreenType = command.QCScreenType;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
