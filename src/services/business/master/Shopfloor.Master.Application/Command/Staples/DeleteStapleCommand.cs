using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Staples
{
    public class DeleteStapleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteStapleCommandHandler : IRequestHandler<DeleteStapleCommand, Response<int>>
    {
        private readonly IStapleRepository _repository;
        public DeleteStapleCommandHandler(IStapleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteStapleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Staple Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
