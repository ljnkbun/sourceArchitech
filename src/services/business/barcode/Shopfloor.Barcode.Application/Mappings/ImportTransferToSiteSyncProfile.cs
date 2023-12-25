using AutoMapper;
using Shopfloor.Barcode.Application.Command.ImportTransferToSiteSyns;
using Shopfloor.Barcode.Application.Models.ImportTransferToSiteSyncs;
using Shopfloor.Barcode.Application.Parameters.ImportTransferToSiteSyncs;
using Shopfloor.Barcode.Application.Query.ImportTransferToSiteSyncs;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class ImportTransferToSiteSyncProfile : Profile
    {
        public ImportTransferToSiteSyncProfile()
        {
           
            CreateMap<ImportTransferToSiteSync,ImportTransferToSiteSyncModel>().ReverseMap();
            CreateMap<GetImportTransferToSiteSyncsQuery, ImportTransferToSiteSyncParameter>();
            CreateMap<CreateImportTransferToSiteSyncCommand, ImportTransferToSiteSync>();
        }
    }
   
}
