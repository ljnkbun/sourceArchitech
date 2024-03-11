using AutoMapper;
using Shopfloor.Master.Application.Command.Lines;
using Shopfloor.Master.Application.Models.Lines;
using Shopfloor.Master.Application.Parameters.Lines;
using Shopfloor.Master.Application.Query.Lines;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Lines
{
    public class LineProfile : Profile
    {
        public LineProfile()
        {
            CreateMap<Line, LineModel>().ReverseMap();
            CreateMap<CreateLineCommand, Line>();
            CreateMap<GetLinesQuery, LineParameter>();
        }
    }
}
