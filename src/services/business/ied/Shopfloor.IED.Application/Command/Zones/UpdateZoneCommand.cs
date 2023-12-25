using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Zones
{
    public class UpdateZoneCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal ZoneSalary { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateZoneCommandHandler : IRequestHandler<UpdateZoneCommand, Response<int>>
    {
        private readonly IZoneRepository _repository;
        public UpdateZoneCommandHandler(IZoneRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateZoneCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"Zone Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.ZoneSalary = command.ZoneSalary;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
