using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportDetails
{
    public class DeleteImportDetailsCommand : IRequest<Response<List<int>>>
    {
        public string Ids { get; set; }
    }

    public class DeleteImportDetailsCommandHandler : IRequestHandler<DeleteImportDetailsCommand, Response<List<int>>>
    {
        private readonly IImportDetailRepository _repository;
        public DeleteImportDetailsCommandHandler(IImportDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<List<int>>> Handle(DeleteImportDetailsCommand command, CancellationToken cancellationToken)
        {
            var intIds = command.Ids.Split(',').Select(x=>int.Parse(x)).ToArray();
            var detailsDeleted = await _repository.GetByIdsAsync(intIds);
            await _repository.DeleteImportTransferToSiteDetaisAsync(detailsDeleted);
            return new Response<List<int>>(detailsDeleted.Select(x => x.Id).ToList());
        }
    }
}
