using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.RequestDivisions;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Requests
{
    public class UpdateRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; }
        public int RequestTypeId { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UpdateRequestDivisionCommand> RequestDivisions { get; set; }
    }
    public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, Response<int>>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IRequestDivisionRepository _requestDivisionRepository;
        private readonly IMapper _mapper;

        public UpdateRequestCommandHandler(IRequestRepository requestRepository, IRequestDivisionRepository requestDivisionRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _requestDivisionRepository = requestDivisionRepository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _requestRepository.GetByIdAsync(command.Id);
            if (entity == null)
                throw new ApiException($"{nameof(Request)} Not Found.");

            entity.Description = command.Description;
            entity.Status = command.Status;
            entity.RequestTypeId = command.RequestTypeId;
            entity.Deleted = command.Deleted;
            entity.IsActive = command.IsActive;
            entity.RequestDivisions = null;

            var deletedRequestDivisions = await _requestDivisionRepository.GetListAsync(command.Id);                                                                                                           // || !command.ProductCategories.Any(v => v.Id == x.Id)).ToList();
            var insertRequestDivisions = command.RequestDivisions?.Select(x => new RequestDivision
            {
                RequestId = command.Id,
                DivisionId = x.DivisionId,
                DivisionCode = x.DivisionCode,
                DivisionName = x.DivisionName,
                LineNumber = x.LineNumber,
                Status = x.Status,
                IsActive = x.IsActive,
                RequestDivisionProcesses = _mapper.Map<ICollection<RequestDivisionProcess>>(x.RequestDivisionProcesses)
            }).ToList();

            await _requestRepository.UpdateRequestAsync(entity, insertRequestDivisions, deletedRequestDivisions);
            return new Response<int>(entity.Id);
        }
    }
}
