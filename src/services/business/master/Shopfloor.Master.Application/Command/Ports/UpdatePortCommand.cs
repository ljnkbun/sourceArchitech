using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Ports
{
    public class UpdatePortCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool PortOfLoading { get; set; }
        public bool PortOfDischarge { get; set; }
        public bool PortOfReceiptByPreCarrier { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdatePortCommandHandler : IRequestHandler<UpdatePortCommand, Response<int>>
    {
        private readonly IPortRepository _repository;
        public UpdatePortCommandHandler(IPortRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdatePortCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Port Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.PortOfLoading = command.PortOfLoading;
            entity.PortOfDischarge = command.PortOfDischarge;
            entity.PortOfReceiptByPreCarrier = command.PortOfReceiptByPreCarrier;
            entity.CountryId = command.CountryId;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
