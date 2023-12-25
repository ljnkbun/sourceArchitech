using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportDetails
{
    public class DeleteExportDetailsCommand : IRequest<Response<int[]>>
    {
        public string Ids { get; set; }
    }

    public class DeleteExportDetailsCommandHandler : IRequestHandler<DeleteExportDetailsCommand, Response<int[]>>
    {
        private readonly IExportDetailRepository _repository;
        public DeleteExportDetailsCommandHandler(IExportDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int[]>> Handle(DeleteExportDetailsCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(command.Ids)) throw new ApiException($"ExportDetails Not Found");
            var ids = command.Ids.Split(",").Select(int.Parse).ToArray();
            var entities = await _repository.GetByIdsAsync(ids) ?? throw new ApiException($"ExportDetail Not Found (Id:{command.Ids}).");
            await _repository.DeleteRangeAsync(entities.ToList());
            return new Response<int[]>(ids);
        }
    }
}
