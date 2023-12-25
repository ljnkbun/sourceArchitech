using AutoMapper;
using Shopfloor.IED.Application.Command.SewingTaskLibs;
using Shopfloor.IED.Application.Models.SewingTaskLibs;
using Shopfloor.IED.Application.Parameters.SewingTaskLibs;
using Shopfloor.IED.Application.Query.SewingTaskLibs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingTaskLibs
{
    public class SewingTaskLibProfile : Profile
    {
        public SewingTaskLibProfile()
        {
            CreateMap<SewingTaskLib, SewingTaskLibModel>().ReverseMap();
            CreateMap<CreateSewingTaskLibCommand, SewingTaskLib>();
            CreateMap<GetSewingTaskLibsQuery, SewingTaskLibParameter>();
        }
    }
}
