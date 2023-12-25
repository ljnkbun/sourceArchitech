using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Requests
{
    public class UpdateRequestStatusCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public RequestStatus Status { get; set; }
    }
    public class UpdateRequestStatusCommandHandler : IRequestHandler<UpdateRequestStatusCommand, Response<int>>
    {
        private readonly IRequestRepository _requestRepository;

        public UpdateRequestStatusCommandHandler(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public async Task<Response<int>> Handle(UpdateRequestStatusCommand command, CancellationToken cancellationToken)
        {
            var entity = await _requestRepository.GetByIdAsync(command.Id);
            if (entity == null)
                throw new ApiException($"{nameof(Request)} Not Found.");

            if(command.Status <= entity.Status)
            {
                throw new ApiException($"Action is denied");
            }

            entity.Status = command.Status;
            await _requestRepository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
