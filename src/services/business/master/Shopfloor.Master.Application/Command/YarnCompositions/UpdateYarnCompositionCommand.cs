using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.YarnCompositions
{
    public class UpdateYarnCompositionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateYarnCompositionCommandHandler : IRequestHandler<UpdateYarnCompositionCommand, Response<int>>
    {
        private readonly IYarnCompositionRepository _repository;
        public UpdateYarnCompositionCommandHandler(IYarnCompositionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateYarnCompositionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"YarnComposition Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
