using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Constructions
{
    public class UpdateConstructionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateConstructionCommandHandler : IRequestHandler<UpdateConstructionCommand, Response<int>>
    {
        private readonly IConstructionRepository _repository;
        public UpdateConstructionCommandHandler(IConstructionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateConstructionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"Construction Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
