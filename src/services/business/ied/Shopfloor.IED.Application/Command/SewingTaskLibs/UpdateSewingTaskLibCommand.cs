using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingTaskLibs
{
    public class UpdateSewingTaskLibCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Freq { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal BundelTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateSewingTaskLibCommandHandler : IRequestHandler<UpdateSewingTaskLibCommand, Response<int>>
    {
        private readonly ISewingTaskLibRepository _repository;
        public UpdateSewingTaskLibCommandHandler(ISewingTaskLibRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateSewingTaskLibCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"SewingTaskLib Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.Description = command.Description;
            entity.Freq = command.Freq;
            entity.TotalTMU = command.TotalTMU;
            entity.Deleted = command.Deleted;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
