using AutoMapper;
using Shopfloor.Inspection.Application.Command.QCDefects;
using Shopfloor.Inspection.Application.Models.QCDefects;
using Shopfloor.Inspection.Application.Parameters.QCDefects;
using Shopfloor.Inspection.Application.Query.QCDefects;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.QCDefects
{
    public class QCDefectProfile : Profile
    {
        public QCDefectProfile()
        {
            CreateMap<QCDefect, QCDefectModel>().ReverseMap();
            CreateMap<CreateQCDefectCommand, QCDefect>();
            CreateMap<GetQCDefectsQuery, QCDefectParameter>();
        }
    }
}
