using AutoMapper;
using Shopfloor.Barcode.Application.Command.ExportDetails;
using Shopfloor.Barcode.Application.Models.ExportDetails;
using Shopfloor.Barcode.Application.Parameters.ExportDetails;
using Shopfloor.Barcode.Application.Query.ExportDetails;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class ExportDetailProfile : Profile
    {
        public ExportDetailProfile()
        {
            CreateMap<ExportDetail, ExportDetailModel>().ReverseMap();
            CreateMap<ExportDetail, ExportDetailExcelModel>().ReverseMap();
            CreateMap<GetExportDetailsQuery, ExportDetailParameter>();
            CreateMap<CreateExportDetailCommand, ExportDetail>();
            CreateMap<UpdateExportDetailCommand, ExportDetail>();
        }
    }
}
