using AutoMapper;
using Shopfloor.IED.Application.Command.FormulaFields;
using Shopfloor.IED.Application.Models.FormulaFields;
using Shopfloor.IED.Application.Parameters.FormulaFields;
using Shopfloor.IED.Application.Query.FormulaFields;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.FormulaFields
{
    public class FormulaFieldProfile : Profile
    {
        public FormulaFieldProfile()
        {
            CreateMap<FormulaField, FormulaFieldModel>().ReverseMap();
            CreateMap<CreateFormulaFieldCommand, FormulaField>();
            CreateMap<GetFormulaFieldsQuery, FormulaFieldParameter>();
        }
    }
}
