using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportDetails
{
    public class UpdateImportDetailsCommand : IRequest<Response<List<int>>>
    {
        public ICollection<UpdateImportDetailCommand> updateImportDetailCommands { get; set; }
    }

    public class UpdateImportDetailsCommandHandler : IRequestHandler<UpdateImportDetailsCommand, Response<List<int>>>
    {
        private readonly IImportDetailRepository _repository;
        private readonly IMapper _mapper;
        public UpdateImportDetailsCommandHandler(IImportDetailRepository repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<int>>> Handle(UpdateImportDetailsCommand command, CancellationToken cancellationToken)
        {
            var intIds = command.updateImportDetailCommands.Select(x => x.Id).ToArray();
            var oldDetails = await _repository.GetByIdsAsync(intIds);
            List<ImportDetail> importTransferToSiteDetails = new List<ImportDetail>();
            foreach (var newDetail in command.updateImportDetailCommands)
            {
                var detail = oldDetails.Find(x => x.Id == newDetail.Id);
                if (detail != null)
                {
                    _mapper.Map<UpdateImportDetailCommand, ImportDetail>(newDetail, detail);
                    importTransferToSiteDetails.Add(detail);
                }
            }
            await _repository.UpdateRangeAsync(importTransferToSiteDetails);
            return new Response<List<int>>(importTransferToSiteDetails.Select(x => x.Id).ToList());
        }
    }
}
