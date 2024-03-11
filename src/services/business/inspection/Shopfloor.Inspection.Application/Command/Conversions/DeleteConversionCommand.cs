using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.Conversions
{
    public class DeleteConversionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteConversionCommandHandler : IRequestHandler<DeleteConversionCommand, Response<int>>
    {
        private readonly IConversionRepository _repository;
        public DeleteConversionCommandHandler(IConversionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteConversionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Conversion Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
