using AutoMapper;
using Shopfloor.Production.Application.Command.DefectCapturing4Pointss;
using Shopfloor.Production.Application.Models.DefectCapturing4Pointss;
using Shopfloor.Production.Application.Parameters.DefectCapturing4Pointss;
using Shopfloor.Production.Application.Query.DefectCapturing4Pointss;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Application.Mappings
{
    public class DefectCapturing4PointsProfile : Profile
    {
        public DefectCapturing4PointsProfile()
        {
            CreateMap<DefectCapturing4Points, DefectCapturing4PointsModel>().ReverseMap();
            CreateMap<CreateDefectCapturing4PointsCommand, DefectCapturing4Points>();
            CreateMap<GetDefectCapturing4PointssQuery, DefectCapturing4PointsParameter>();
        }
    }
}
