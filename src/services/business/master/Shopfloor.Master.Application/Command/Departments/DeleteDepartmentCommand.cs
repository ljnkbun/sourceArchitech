using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Departments
{
    public class DeleteDepartmentCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, Response<int>>
    {
        private readonly IDepartmentRepository _repository;
        public DeleteDepartmentCommandHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Department Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
