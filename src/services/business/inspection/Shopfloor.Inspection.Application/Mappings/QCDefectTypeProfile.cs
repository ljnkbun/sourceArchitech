using AutoMapper;
using Shopfloor.Inspection.Application.Command.QCDefectTypes;
using Shopfloor.Inspection.Application.Models.QCDefectTypes;
using Shopfloor.Inspection.Application.Parameters.QCDefectTypes;
using Shopfloor.Inspection.Application.Query.QCDefectTypes;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.QCDefectTypes
{
    public class QCDefectTypeProfile : Profile
    {
        public QCDefectTypeProfile()
        {
            CreateMap<QCDefectType, QCDefectTypeModel>().ReverseMap();
            CreateMap<CreateQCDefectTypeCommand, QCDefectType>();
            CreateMap<GetQCDefectTypesQuery, QCDefectTypeParameter>();
        }
    }
}
