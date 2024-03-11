using AutoMapper;
using MassTransit;
using MediatR;
using Shopfloor.Inspection.Domain.Enums;
using Shopfloor.Inspection.Domain.Interfaces;
using Responses = Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Imports
{
    public class UpdateQCRequestStatusCommand : IRequest<Responses.Response<int>>
    {
        public int Id { get; set; }
        public QCRequestStatus QCRequestStatus { get; set; }
    }
    public class UpdateQCRequestStatusCommandHandler : IRequestHandler<UpdateQCRequestStatusCommand, Responses.Response<int>>
    {
        private readonly IQCRequestRepository _repository;

        public UpdateQCRequestStatusCommandHandler(IQCRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Responses.Response<int>> Handle(UpdateQCRequestStatusCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null) return new($"QCRequest Not Found.(Id:{request.Id})");
            entity.QCRequestStatus = request.QCRequestStatus;
            await _repository.UpdateAsync(entity);
            return new Responses.Response<int>(entity.Id);
        }
    }
}
