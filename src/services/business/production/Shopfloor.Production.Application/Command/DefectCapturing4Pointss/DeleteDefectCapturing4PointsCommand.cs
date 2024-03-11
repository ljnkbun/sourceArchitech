using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.DefectCapturing4Pointss
{
    public class DeleteDefectCapturing4PointsCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteDefectCapturing4PointsCommandHandler : IRequestHandler<DeleteDefectCapturing4PointsCommand, Response<int>>
    {
        private readonly IDefectCapturing4PointsRepository _repository;
        public DeleteDefectCapturing4PointsCommandHandler(IDefectCapturing4PointsRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteDefectCapturing4PointsCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"DefectCapturing4Points Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
