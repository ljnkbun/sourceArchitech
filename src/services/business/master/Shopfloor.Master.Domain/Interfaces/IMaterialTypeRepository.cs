using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IMaterialTypeRepository : IMasterRepositoryAsync<MaterialType>
    {
        Task<MaterialType> GetMaterialTypeByIdAsync(int id);

        Task UpdateMaterialTypeAsync(MaterialType entity,
            BaseUpdateEntity<CategoryMapMaterialType> categoryMapMaterialTypes);

        Task<PagedResponse<IReadOnlyList<TModel>>> GetMaterialTypePagedResponseAsync<TParam, TModel>(TParam parameter)
            where TParam : RequestParameter where TModel : class;
    }
}
