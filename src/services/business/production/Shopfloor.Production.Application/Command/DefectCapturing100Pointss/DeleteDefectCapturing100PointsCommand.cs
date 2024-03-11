using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.DefectCapturing100Pointss
{
    public class DeleteDefectCapturing100PointsCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteDefectCapturing100PointsCommandHandler : IRequestHandler<DeleteDefectCapturing100PointsCommand, Response<int>>
    {
        private readonly IDefectCapturing100PointsRepository _repository;
        public DeleteDefectCapturing100PointsCommandHandler(IDefectCapturing100PointsRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteDefectCapturing100PointsCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"DefectCapturing100Points Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
