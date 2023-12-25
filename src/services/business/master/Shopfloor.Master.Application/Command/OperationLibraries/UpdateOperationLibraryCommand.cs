using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.OperationLibraries
{
    public class UpdateOperationLibraryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ProcessLibraryId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateOperationLibraryCommandHandler : IRequestHandler<UpdateOperationLibraryCommand, Response<int>>
    {
        private readonly IOperationLibraryRepository _repository;
        public UpdateOperationLibraryCommandHandler(IOperationLibraryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateOperationLibraryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"OperationLibrary Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.ProcessLibraryId = command.ProcessLibraryId;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
