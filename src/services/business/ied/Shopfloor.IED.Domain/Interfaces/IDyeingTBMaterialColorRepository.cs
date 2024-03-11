using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDyeingTBMaterialColorRepository : IGenericRepositoryAsync<DyeingTBMaterialColor>
{
    Task<bool> IsExistAsync(int id);

    Task<PagedResponse<IReadOnlyList<TModel>>> GetMaterialColorPagedResponseAsync<TParam, TModel>(TParam parameter)
        where TParam : RequestParameter where TModel : class;

    Task<DyeingTBMaterialColor> GetWithParentByIdAsync(int id);
}