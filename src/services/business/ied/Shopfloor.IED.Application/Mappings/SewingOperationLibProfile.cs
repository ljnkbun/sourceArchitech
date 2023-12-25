using AutoMapper;
using Shopfloor.IED.Application.Command.SewingOperationLibs;
using Shopfloor.IED.Application.Models.SewingOperationLibBOLs;
using Shopfloor.IED.Application.Models.SewingOperationLibs;
using Shopfloor.IED.Application.Parameters.SewingOperationLibs;
using Shopfloor.IED.Application.Query.SewingOperationLibs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingOperationLibs
{
    public class SewingOperationLibProfile : Profile
    {
        public SewingOperationLibProfile()
        {
            CreateMap<SewingOperationLib, SewingOperationLibModel>().ReverseMap();
            CreateMap<CreateSewingOperationLibCommand, SewingOperationLib>();
            CreateMap<GetSewingOperationLibsQuery, SewingOperationLibParameter>();
            CreateMap<SewingOperationLibBOLModel, SewingOperationLibBOL>();
        }
    }
}
