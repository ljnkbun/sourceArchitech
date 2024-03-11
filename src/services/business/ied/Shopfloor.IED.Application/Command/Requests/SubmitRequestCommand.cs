using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Requests
{
    public class SubmitRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class SubmitRequestCommandHandler : IRequestHandler<SubmitRequestCommand, Response<int>>
    {
        private readonly IRequestRepository _requestRepository;
        public SubmitRequestCommandHandler(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public async Task<Response<int>> Handle(SubmitRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _requestRepository.GetByIdAsync(command.Id);
            if (entity == null)
                return new($"{nameof(Request)} Not Found.");

            int createdRequests = await _requestRepository.SubmitRequestAsync(command.Id, entity.RequestNo);
            return new Response<int>(entity.Id, $"{createdRequests} division request(s) created.");
        }
    }
}
