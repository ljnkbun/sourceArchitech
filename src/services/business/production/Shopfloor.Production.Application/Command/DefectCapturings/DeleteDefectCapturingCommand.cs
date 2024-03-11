using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.DefectCapturings
{
    public class DeleteDefectCapturingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteDefectCapturingCommandHandler : IRequestHandler<DeleteDefectCapturingCommand, Response<int>>
    {
        private readonly IDefectCapturingRepository _repository;
        public DeleteDefectCapturingCommandHandler(IDefectCapturingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteDefectCapturingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"DefectCapturing Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
