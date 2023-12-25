using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Requests
{
    public class RejectRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string RejectReason { get; set; }
    }
    public class RejectRequestCommandHandler : IRequestHandler<RejectRequestCommand, Response<int>>
    {
        private readonly IRequestRepository _requestRepository;

        public RejectRequestCommandHandler(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public async Task<Response<int>> Handle(RejectRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _requestRepository.GetByIdAsync(command.Id);
            if (entity == null)
                throw new ApiException($"{nameof(Request)} Not Found.");

            if(entity.Status == RequestStatus.TransferredToWFX)
            {
                throw new ApiException($"Action is denied");
            }

            entity.Status = RequestStatus.New;
            entity.StatusComment = command.RejectReason;

            await _requestRepository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
