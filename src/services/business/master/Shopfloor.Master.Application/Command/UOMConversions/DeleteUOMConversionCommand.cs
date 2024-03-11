using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.UOMConversions
{
    public class DeleteUOMConversionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteUOMConversionCommandHandler : IRequestHandler<DeleteUOMConversionCommand, Response<int>>
    {
        private readonly IUOMConversionRepository _repository;
        public DeleteUOMConversionCommandHandler(IUOMConversionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteUOMConversionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"UOMConversion Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
