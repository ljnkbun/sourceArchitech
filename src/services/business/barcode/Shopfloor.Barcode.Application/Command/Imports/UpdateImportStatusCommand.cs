using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Imports
{
    public class UpdateImportStatusCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public ImportStatus? Status { get; set; }
    }
    public class UpdateStatusImportCommandHandler : IRequestHandler<UpdateImportStatusCommand, Response<int>>
    {
        private readonly IMapper _mapper;

        private readonly IImportRepository _repositoryImport;

        public UpdateStatusImportCommandHandler(IMapper mapper, ILogger<UpdateImportStatusCommand> logger,
            IImportRepository repositoryImport)
        {
            _repositoryImport = repositoryImport;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateImportStatusCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _repositoryImport.GetByIdAsync(request.Id) ?? throw new ApiException($"Import Not Found.(Id:{request.Id})");
            entity.Status = request.Status;
            await _repositoryImport.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
