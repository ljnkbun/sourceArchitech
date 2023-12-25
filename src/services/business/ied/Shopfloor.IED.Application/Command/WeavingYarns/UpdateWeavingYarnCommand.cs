using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingYarns
{
    public class UpdateWeavingYarnCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public YarnType YarnType { get; set; }
        public string YarnCode { get; set; }
        public string YarnName { get; set; }
        public decimal YarnInRappo { get; set; }
        public decimal YarnRatio { get; set; }
        public decimal SizingRatio { get; set; }
        public decimal ScaleRatio { get; set; }
        public decimal ScrapRatio { get; set; }
        public decimal Weight { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateWeavingYarnCommandHandler : IRequestHandler<UpdateWeavingYarnCommand, Response<int>>
    {
        private readonly IWeavingYarnRepository _repository;
        public UpdateWeavingYarnCommandHandler(IWeavingYarnRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingYarnCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"WeavingYarn Not Found.");

            entity.LineNumber = command.LineNumber;
            entity.YarnType = command.YarnType;
            entity.YarnCode = command.YarnCode;
            entity.YarnName = command.YarnName;
            entity.YarnInRappo = command.YarnInRappo;
            entity.YarnRatio = command.YarnRatio;
            entity.SizingRatio = command.SizingRatio;
            entity.ScaleRatio = command.ScaleRatio;
            entity.ScrapRatio = command.ScrapRatio;
            entity.Weight = command.Weight;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
