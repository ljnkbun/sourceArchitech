using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Factories
{
    public class UpdateFactoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? DivisionId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateFactoryCommandHandler : IRequestHandler<UpdateFactoryCommand, Response<int>>
    {
        private readonly IFactoryRepository _repository;
        public UpdateFactoryCommandHandler(IFactoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateFactoryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Factory Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.DivisionId = command.DivisionId;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
