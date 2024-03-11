using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingYarns
{
    public class UpdateKnittingYarnCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public int WFXYarnId { get; set; }
        public string YarnName { get; set; }
        public string YarnCode { get; set; }
        public string Color { get; set; }
        public decimal YarnRatio { get; set; }
        public decimal Weight { get; set; }
        public decimal Wastage { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateKnittingYarnCommandHandler : IRequestHandler<UpdateKnittingYarnCommand, Response<int>>
    {
        private readonly IKnittingYarnRepository _repository;
        public UpdateKnittingYarnCommandHandler(IKnittingYarnRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateKnittingYarnCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"KnittingYarn Not Found.");

            entity.LineNumber = command.LineNumber;
            entity.WFXYarnId = command.WFXYarnId;
            entity.YarnName = command.YarnName;
            entity.YarnCode = command.YarnCode;
            entity.Color = command.Color;
            entity.YarnRatio = command.YarnRatio;
            entity.Weight = command.Weight;
            entity.Wastage = command.Wastage;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
