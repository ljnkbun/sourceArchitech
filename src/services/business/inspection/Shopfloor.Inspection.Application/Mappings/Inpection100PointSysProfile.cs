using AutoMapper;
using Shopfloor.Inspection.Application.Command.Inpection100PointSyss;
using Shopfloor.Inspection.Application.Models.Inpection100PointSyss;
using Shopfloor.Inspection.Application.Parameters.Inpection100PointSyss;
using Shopfloor.Inspection.Application.Query.Inpection100PointSyss;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.Inpection100PointSyss
{
    public class Inpection100PointSysProfile : Profile
    {
        public Inpection100PointSysProfile()
        {
            CreateMap<Inpection100PointSys, Inpection100PointSysModel>().ReverseMap();
            CreateMap<CreateInpection100PointSysCommand, Inpection100PointSys>();
            CreateMap<GetInpection100PointSyssQuery, Inpection100PointSysParameter>();
        }
    }
}
