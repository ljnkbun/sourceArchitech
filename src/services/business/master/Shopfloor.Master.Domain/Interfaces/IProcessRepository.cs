using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IProcessRepository : IMasterRepositoryAsync<Process>
    {
        Task<PagedResponse<IReadOnlyList<TModel>>>
            GetProcessBySubCategoryCodePagedResponseAsync<TParam, TModel>(TParam parameter, string code)
            where TParam : RequestParameter where TModel : class;

        Task<PagedResponse<IReadOnlyList<TModel>>>
            GetProcessByDivisionCodePagedResponseAsync<TParam, TModel>(TParam parameter, string code)
            where TParam : RequestParameter where TModel : class;

        Task<bool> IsExistAsync(int id);
        Task<Process> GetProcessInculdeLineMachine(int id);
        Task<bool> UpdateWFXProcess(List<Process> newProcess, List<Process> modProcess);
    }
}