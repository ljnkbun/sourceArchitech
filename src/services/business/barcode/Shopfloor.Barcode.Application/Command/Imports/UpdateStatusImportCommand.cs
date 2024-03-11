using AutoMapper;
using MassTransit;
using MediatR;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Responses = Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Imports
{
    public class UpdateStatusImportCommand : IRequest<Responses.Response<int>>
    {
        public int Id { get; set; }
        public ImportStatus? Status { get; set; }
    }
    public class UpdateStatusImportCommandHandler : IRequestHandler<UpdateStatusImportCommand, Responses.Response<int>>
    {
        private readonly IMapper _mapper;

        private readonly IImportRepository _repositoryImport;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateStatusImportCommandHandler(IMapper mapper,
            IImportRepository repositoryImport
            , IPublishEndpoint publishEndpoint
            )
        {
            _repositoryImport = repositoryImport;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }

        public async Task<Responses.Response<int>> Handle(UpdateStatusImportCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _repositoryImport.GetByIdAsync(request.Id);
            if (entity == null) return new($"Import Not Found.(Id:{request.Id})");
            entity.Status = request.Status;
            await _repositoryImport.UpdateAsync(entity);

            await _publishEndpoint.Publish(new EventBus.Models.Message.UpdateStatusImportsMessage(new int[] { entity.Id }, _mapper.Map<EventBus.Definations.NoteStatus>(request.Status)), cancellationToken);
            return new Responses.Response<int>(entity.Id);
        }
    }
}
