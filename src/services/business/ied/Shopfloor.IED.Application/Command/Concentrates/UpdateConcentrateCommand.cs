using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Concentrates
{
    public class UpdateConcentrateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateConcentrateCommandHandler : IRequestHandler<UpdateConcentrateCommand, Response<int>>
    {
        private readonly IConcentrateRepository _repository;
        public UpdateConcentrateCommandHandler(IConcentrateRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateConcentrateCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Concentrate Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
