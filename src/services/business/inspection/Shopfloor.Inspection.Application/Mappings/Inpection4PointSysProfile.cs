using AutoMapper;
using Shopfloor.Inspection.Application.Command.Inpection4PointSyss;
using Shopfloor.Inspection.Application.Models.Inpection4PointSyss;
using Shopfloor.Inspection.Application.Parameters.Inpection4PointSyss;
using Shopfloor.Inspection.Application.Query.Inpection4PointSyss;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.Inpection4PointSyss
{
    public class Inpection4PointSysProfile : Profile
    {
        public Inpection4PointSysProfile()
        {
            CreateMap<Inpection4PointSys, Inpection4PointSysModel>().ReverseMap();
            CreateMap<CreateInpection4PointSysCommand, Inpection4PointSys>();
            CreateMap<GetInpection4PointSyssQuery, Inpection4PointSysParameter>();
        }
    }
}
