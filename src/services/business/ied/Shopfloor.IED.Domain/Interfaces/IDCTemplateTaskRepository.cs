using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDCTemplateTaskRepository : IGenericRepositoryAsync<DCTemplateTask>
{
    Task<bool> IsExistAsync(int id);

    Task<DCTemplateTask> GetWithIncludeByIdAsync(int id);
}