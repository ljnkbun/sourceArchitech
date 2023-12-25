using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDCTemplateRepository : IMasterRepositoryAsync<DCTemplate>
{
    Task<bool> IsExistAsync(int id);

    Task<DCTemplate> GetWithIncludeByIdAsync(int id);
}