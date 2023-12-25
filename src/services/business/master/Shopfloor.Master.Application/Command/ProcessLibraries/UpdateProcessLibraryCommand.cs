using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ProcessLibraries
{
    public class UpdateProcessLibraryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateProcessLibraryCommandHandler : IRequestHandler<UpdateProcessLibraryCommand, Response<int>>
    {
        private readonly IProcessLibraryRepository _repository;
        public UpdateProcessLibraryCommandHandler(IProcessLibraryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateProcessLibraryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"ProcessLibrary Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
