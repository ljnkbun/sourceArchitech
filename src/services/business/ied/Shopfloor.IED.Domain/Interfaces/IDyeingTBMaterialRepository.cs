using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDyeingTBMaterialRepository : IGenericRepositoryAsync<DyeingTBMaterial>
{
    Task<bool> IsExistAsync(int id);

    Task<DyeingTBMaterial> GetWithIncludeByIdAsync(int id);

    Task<PagedResponse<IReadOnlyList<TModel>>> GetMaterialPagedResponseAsync<TParam, TModel>(TParam parameter)
        where TParam : RequestParameter where TModel : class;
}