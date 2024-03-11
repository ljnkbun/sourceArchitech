using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingIEDs
{
    public class DeleteSewingIEDCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingIEDCommandHandler : IRequestHandler<DeleteSewingIEDCommand, Response<int>>
    {
        private readonly ISewingIEDRepository _repository;
        public DeleteSewingIEDCommandHandler(ISewingIEDRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingIEDCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SewingIED Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
