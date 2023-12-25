using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Requests
{
    public class ApproveRequestCommand : IRequest<Response<bool>>
    {
        public List<int> RequestIds { get; set; }
    }
    public class ApproveRequestCommandHandler : IRequestHandler<ApproveRequestCommand, Response<bool>>
    {
        private readonly IRequestRepository _requestRepository;

        public ApproveRequestCommandHandler(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public async Task<Response<bool>> Handle(ApproveRequestCommand command, CancellationToken cancellationToken)
        {
            var result = await _requestRepository.ApproveRequestsAsync(command.RequestIds);
            return new Response<bool>(result);
        }
    }
}
