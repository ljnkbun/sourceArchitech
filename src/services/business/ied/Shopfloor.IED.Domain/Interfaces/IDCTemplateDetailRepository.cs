using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDCTemplateDetailRepository : IGenericRepositoryAsync<DCTemplateDetail>
{
    Task<bool> IsExistAsync(int id);
}