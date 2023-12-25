using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingIEDs
{
    public class UpdateWeavingIEDCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string RequestNo { get; set; }
        public string Comment { get; set; }
        public Status Status { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateWeavingIEDCommandHandler : IRequestHandler<UpdateWeavingIEDCommand, Response<int>>
    {
        private readonly IWeavingIEDRepository _repository;
        public UpdateWeavingIEDCommandHandler(IWeavingIEDRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingIEDCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"WeavingIED Not Found.");

            entity.RequestNo = command.RequestNo;
            entity.Comment = command.Comment;
            entity.Status = command.Status;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
