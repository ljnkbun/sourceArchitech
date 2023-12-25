using AutoMapper;
using Shopfloor.IED.Application.Command.LabourSkills;
using Shopfloor.IED.Application.Models.LabourSkills;
using Shopfloor.IED.Application.Parameters.LabourSkills;
using Shopfloor.IED.Application.Query.LabourSkills;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.LabourSkills
{
    public class LabourSkillProfile : Profile
    {
        public LabourSkillProfile()
        {
            CreateMap<LabourSkill, LabourSkillModel>().ReverseMap();
            CreateMap<CreateLabourSkillCommand, LabourSkill>();
            CreateMap<GetLabourSkillsQuery, LabourSkillParameter>();
        }
    }
}
