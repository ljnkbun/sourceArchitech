using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SubOperationLibraries
{
    public class UpdateSubOperationLibraryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int OperationLibraryId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateSubOperationLibraryCommandHandler : IRequestHandler<UpdateSubOperationLibraryCommand, Response<int>>
    {
        private readonly ISubOperationLibraryRepository _repository;
        public UpdateSubOperationLibraryCommandHandler(ISubOperationLibraryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateSubOperationLibraryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"SubOperationLibrary Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.OperationLibraryId = command.OperationLibraryId;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
