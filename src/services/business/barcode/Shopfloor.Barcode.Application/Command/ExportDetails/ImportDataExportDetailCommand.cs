using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shopfloor.Barcode.Application.Definitions;
using Shopfloor.Barcode.Application.Models.ExportDetails;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportDetails
{
    public class ImportDataExportDetailCommand : IRequest<Response<List<ExportDetail>>>
    {
        public IFormFile File { get; set; }

    }

    public class ImportDataExportDetailCommandHandler : IRequestHandler<ImportDataExportDetailCommand, Response<List<ExportDetail>>>
    {
        private readonly IMapper _mapper;
        public ImportDataExportDetailCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Response<List<ExportDetail>>> Handle(ImportDataExportDetailCommand request, CancellationToken cancellationToken)
        {
            var input = new ImportExcelModel(0, 2, FieldMaps.ExportDetail);
            var data = ImportExcelHelper.ReadExcel<ExportDetailExcelModel>(request.File, input);
            if (data == null || data.Count == 0)
                return new Response<List<ExportDetail>>(null, "No data import");
            var entities = _mapper.Map<List<ExportDetail>>(data);

            return new Response<List<ExportDetail>>(entities);
        }
    }
}
