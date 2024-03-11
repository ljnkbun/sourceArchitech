using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDyeingTBRequestRepository : IGenericRepositoryAsync<DyeingTBRequest>
{
    Task<bool> IsExistAsync(int id);

    Task<DyeingTBRequest> GetWithIncludeByIdAsync(int id);

    Task<DyeingTBRequest> AddDyeingTBRequestAsync(DyeingTBRequest entity);

    Task<PagedResponse<IReadOnlyList<TModel>>> GetRequestPagedResponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class;

    Task<bool> UpdateDyeingTBRequestAsync(DyeingTBRequest dataDyeingTBRequestUpdate,
        BaseUpdateEntity<DyeingTBMaterial> dataDyeingTBMaterial,
        BaseUpdateEntity<DyeingTBMaterialColor> dataDyeingTBMaterialColor);
}