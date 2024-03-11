using AutoMapper;
using Shopfloor.Inspection.Application.Command.QCDefinitions;
using Shopfloor.Inspection.Application.Models.QCDefinitions;
using Shopfloor.Inspection.Application.Parameters.QCDefinitions;
using Shopfloor.Inspection.Application.Query.QCDefinitions;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.QCDefinitions
{
    public class QCDefinitionProfile : Profile
    {
        public QCDefinitionProfile()
        {
            CreateMap<QCDefinition, QCDefinitionModel>().ReverseMap();
            CreateMap<CreateQCDefinitionCommand, QCDefinition>();
            CreateMap<GetQCDefinitionsQuery, QCDefinitionParameter>();
        }
    }
}
