using AutoMapper;
using Shopfloor.Barcode.Application.Command.Imports;
using Shopfloor.Barcode.Application.Models.Imports;
using Shopfloor.Barcode.Application.Parameters.Imports;
using Shopfloor.Barcode.Application.Query.Imports;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class ImportProfile : Profile
    {
        public ImportProfile()
        {
           
            CreateMap<Import, ImportModel>().ReverseMap();
            CreateMap<GetImportsQuery, ImportParameter>();
            CreateMap<CreateImportCommand, Import>().ForMember(x => x.Status, opt => opt.MapFrom(src=> ImportStatus.Processing));
        }
    }
   
}
