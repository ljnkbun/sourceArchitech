using AutoMapper;
using Shopfloor.Inspection.Application.Command.AQLs;
using Shopfloor.Inspection.Application.Command.QCDefinitionDefects;
using Shopfloor.Inspection.Application.Models.QCDefinitionDefects;
using Shopfloor.Inspection.Application.Parameters.QCDefinitionDefects;
using Shopfloor.Inspection.Application.Query.QCDefinitionDefects;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.QCDefinitionDefects
{
    public class QCDefinitionDefectProfile : Profile
    {
        public QCDefinitionDefectProfile()
        {
            CreateMap<QCDefinitionDefect, QCDefinitionDefectModel>().ReverseMap();
            CreateMap<CreateQCDefinitionDefectCommand, QCDefinitionDefect>();
            CreateMap<GetQCDefinitionDefectsQuery, QCDefinitionDefectParameter>();
            CreateMap<UpdateQCDefinitionDefectCommand, QCDefinitionDefect>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
