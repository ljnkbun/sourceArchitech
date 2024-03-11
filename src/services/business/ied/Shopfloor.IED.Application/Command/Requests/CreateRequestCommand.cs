using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.RequestDivisions;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Requests
{
    public class CreateRequestCommand : IRequest<Response<int>>
    {
        public string Description { get; set; }
        public decimal? ExpectedQty { get; set; }
        public int RequestTypeId { get; set; }
        public ICollection<CreateRequestDivisionCommand> RequestDivisions { get; set; }
    }
    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _repository;
        public CreateRequestCommandHandler(IMapper mapper,
            IRequestRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Request>(request);
            entity.Status = RequestStatus.Draft;
            await _repository.AddRequestAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
