using AutoMapper;
using Shopfloor.Barcode.Application.Command.Exports;
using Shopfloor.Barcode.Application.Models.Exports;
using Shopfloor.Barcode.Application.Parameters.Exports;
using Shopfloor.Barcode.Application.Query.Exports;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class ExportProfile : Profile
    {
        public ExportProfile()
        {
            CreateMap<Export, ExportModel>().ReverseMap();
            CreateMap<GetExportsQuery, ExportParameter>();
            CreateMap<CreateExportCommand, Export>();
        }
    }
}
