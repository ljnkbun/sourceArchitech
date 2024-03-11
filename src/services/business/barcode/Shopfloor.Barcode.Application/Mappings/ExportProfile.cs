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
            CreateMap<Export, ExportModel>()
                .ForMember(x => x.ExportArticleModels, d => d.MapFrom(o => o.ExportArticles))
                .ForMember(x => x.Type, d => d.MapFrom(o => o.GDIType))
                .ReverseMap();
            CreateMap<GetExportsQuery, ExportParameter>();
            CreateMap<CreateExportCommand, Export>();
        }
    }
}
