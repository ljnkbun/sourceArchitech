using AutoMapper;
using Shopfloor.IED.Application.Command.Formulas;
using Shopfloor.IED.Application.Models.Formulas;
using Shopfloor.IED.Application.Parameters.Formulas;
using Shopfloor.IED.Application.Query.Formulas;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Formulas
{
    public class FormulaProfile : Profile
    {
        public FormulaProfile()
        {
            CreateMap<Formula, FormulaModel>().ReverseMap();
            CreateMap<CreateFormulaCommand, Formula>();
            CreateMap<GetFormulasQuery, FormulaParameter>();
        }
    }
}
