using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.LiquorRatios
{
    public class DeleteLiquorRatioCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteLiquorRatioCommandHandler : IRequestHandler<DeleteLiquorRatioCommand, Response<int>>
    {
        private readonly ILiquorRatioRepository _repository;
        public DeleteLiquorRatioCommandHandler(ILiquorRatioRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteLiquorRatioCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"LiquorRatio Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
