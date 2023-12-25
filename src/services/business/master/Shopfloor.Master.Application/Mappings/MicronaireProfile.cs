using AutoMapper;
using Shopfloor.Master.Application.Command.Micronaires;
using Shopfloor.Master.Application.Models.Micronaires;
using Shopfloor.Master.Application.Parameters.Micronaires;
using Shopfloor.Master.Application.Query.Micronaires;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Micronaires
{
    public class MicronaireProfile : Profile
    {
        public MicronaireProfile()
        {
            CreateMap<Micronaire, MicronaireModel>().ReverseMap();
            CreateMap<CreateMicronaireCommand, Micronaire>();
            CreateMap<GetMicronairesQuery, MicronaireParameter>();
        }
    }
}
