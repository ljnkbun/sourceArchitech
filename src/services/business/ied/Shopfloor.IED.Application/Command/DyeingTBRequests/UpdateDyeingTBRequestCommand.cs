using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRequests
{
    public class UpdateDyeingTBRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int RequestType { get; set; }

        public DateTime RequestDate { get; set; }

        public string StyleRef { get; set; }

        public string Remark { get; set; }

        public string Buyer { get; set; }

        public string BuyerRef { get; set; }

        public DateTime ExpiredDate { get; set; }

        public TBRequestStatus Status { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateDyeingTBRequestCommandHandler : IRequestHandler<UpdateDyeingTBRequestCommand, Response<int>>
    {
        private readonly IDyeingTBRequestRepository _repository;

        public UpdateDyeingTBRequestCommandHandler(IDyeingTBRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"DyeingTBRequest Not Found.");
            entity.RequestDate = command.RequestDate;
            entity.BuyerRef = command.BuyerRef;
            entity.ExpiredDate = command.ExpiredDate;
            entity.Remark = command.Remark;
            entity.StyleRef = command.StyleRef;
            entity.RequestType = command.RequestType;
            entity.Buyer = command.Buyer;
            entity.Status = command.Status;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}