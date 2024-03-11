using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDyeingIEDRepository : IGenericRepositoryAsync<DyeingIED>
{
    Task<bool> IsExistAsync(int id);

    Task<DyeingIED> GetWithIncludeByIdAsync(int id);

    Task<PagedResponse<IReadOnlyList<TModel>>> GetDyeingIEDPagedResponseAsync<TParam, TModel>(TParam parameter)
        where TParam : RequestParameter where TModel : class;

    Task<PagedResponse<IReadOnlyList<TModel>>> GetSearchDyeingIEDPagedResponseAsync<TParam, TModel>(TParam parameter)
        where TParam : RequestParameter where TModel : class;

    Task UpdateDyeingIEDAsync(DyeingIED dyeingIED, List<DyeingRouting> newDyeingRoutings);
}