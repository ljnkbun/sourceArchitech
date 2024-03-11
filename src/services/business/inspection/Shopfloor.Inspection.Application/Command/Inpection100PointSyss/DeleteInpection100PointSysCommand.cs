using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.Inpection100PointSyss
{
    public class DeleteInpection100PointSysCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteInpection100PointSysCommandHandler : IRequestHandler<DeleteInpection100PointSysCommand, Response<int>>
    {
        private readonly IInpection100PointSysRepository _repository;
        public DeleteInpection100PointSysCommandHandler(IInpection100PointSysRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteInpection100PointSysCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"Inpection100PointSys Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
