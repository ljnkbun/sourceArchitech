using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportDetails
{
    public class CreateExportDetailCommand : IRequest<Response<int>>
    {
        public int? ExportArticleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string LotNo { get; set; }
        public string UOM { get; set; }
        public decimal? Yard { get; set; }
        public decimal? Meter { get; set; }
        public decimal? Unit { get; set; }
        public string Note { get; set; }
        public ItemStatus? Status { get; set; }
    }

    public class CreateExportDetailEntityCommandHandler : IRequestHandler<CreateExportDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IExportDetailRepository _repository;

        public CreateExportDetailEntityCommandHandler(IMapper mapper,
            IExportDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateExportDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ExportDetail>(request);

            var rs = await _repository.AddAsync(entity);
            return new Response<int>(rs.Id);
        }
    }
}
