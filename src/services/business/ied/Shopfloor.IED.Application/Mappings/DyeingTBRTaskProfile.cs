using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingTBRTasks;
using Shopfloor.IED.Application.Models.DyeingTBRTasks;
using Shopfloor.IED.Application.Parameters.DyeingTBRTasks;
using Shopfloor.IED.Application.Query.DyeingTBRTasks;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DyeingTBRTaskProfile : Profile
    {
        public DyeingTBRTaskProfile()
        {
            CreateMap<DyeingTBRTask, DyeingTBRTaskModel>().ReverseMap();
            CreateMap<CreateDyeingTBRTaskCommand, DyeingTBRTask>();
            CreateMap<GetDyeingTBRTasksQuery, DyeingTBRTaskParameter>();
            CreateMap<UpdateDyeingTBRTaskCommand, DyeingTBRTask>();
        }
    }
}