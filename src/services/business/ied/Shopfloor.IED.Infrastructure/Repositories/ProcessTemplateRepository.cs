using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class ProcessTemplateRepository : MasterRepositoryAsync<ProcessTemplate>, IProcessTemplateRepository
    {
        public ProcessTemplateRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
