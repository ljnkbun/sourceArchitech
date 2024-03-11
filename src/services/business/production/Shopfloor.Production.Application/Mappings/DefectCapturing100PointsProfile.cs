using AutoMapper;
using Shopfloor.Production.Application.Command.DefectCapturing100Pointss;
using Shopfloor.Production.Application.Models.DefectCapturing100Pointss;
using Shopfloor.Production.Application.Parameters.DefectCapturing100Pointss;
using Shopfloor.Production.Application.Query.DefectCapturing100Pointss;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Application.Mappings
{
    public class DefectCapturing100PointsProfile : Profile
    {
        public DefectCapturing100PointsProfile()
        {
            CreateMap<DefectCapturing100Points, DefectCapturing100PointsModel>().ReverseMap();
            CreateMap<CreateDefectCapturing100PointsCommand, DefectCapturing100Points>();
            CreateMap<GetDefectCapturing100PointssQuery, DefectCapturing100PointsParameter>();
        }
    }
}
