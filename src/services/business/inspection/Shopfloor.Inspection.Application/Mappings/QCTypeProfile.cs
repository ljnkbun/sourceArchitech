using AutoMapper;
using Shopfloor.Inspection.Application.Command.QCTypes;
using Shopfloor.Inspection.Application.Models.QCTypes;
using Shopfloor.Inspection.Application.Parameters.QCTypes;
using Shopfloor.Inspection.Application.Query.QCTypes;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.QCTypes
{
    public class QCTypeProfile : Profile
    {
        public QCTypeProfile()
        {
            CreateMap<QCType, QCTypeModel>().ReverseMap();
            CreateMap<CreateQCTypeCommand, QCType>();
            CreateMap<GetQCTypesQuery, QCTypeParameter>();
        }
    }
}
