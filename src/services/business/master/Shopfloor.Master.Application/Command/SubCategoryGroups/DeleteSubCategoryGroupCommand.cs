using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SubCategoryGroups
{
    public class DeleteSubCategoryGroupCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSubCategoryGroupCommandHandler : IRequestHandler<DeleteSubCategoryGroupCommand, Response<int>>
    {
        private readonly ISubCategoryGroupRepository _repository;
        public DeleteSubCategoryGroupCommandHandler(ISubCategoryGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSubCategoryGroupCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"SubCategoryGroup Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
