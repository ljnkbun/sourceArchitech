using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingRappoMarks;
using Shopfloor.IED.Application.Models.WeavingRappoMarks;
using Shopfloor.IED.Application.Parameters.WeavingRappoMarks;
using Shopfloor.IED.Application.Query.WeavingRappoMarks;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingRappoMarks
{
    public class WeavingRappoMarkProfile : Profile
    {
        public WeavingRappoMarkProfile()
        {
            CreateMap<WeavingRappoMark, WeavingRappoMarkModel>().ReverseMap();
            CreateMap<CreateWeavingRappoMarkCommand, WeavingRappoMark>();
            CreateMap<GetWeavingRappoMarksQuery, WeavingRappoMarkParameter>();
        }
    }
}
