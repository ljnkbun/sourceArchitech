using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Themes
{
    public class DeleteThemeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteThemeCommandHandler : IRequestHandler<DeleteThemeCommand, Response<int>>
    {
        private readonly IThemeRepository _repository;
        public DeleteThemeCommandHandler(IThemeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteThemeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Theme Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
