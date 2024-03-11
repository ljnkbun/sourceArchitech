using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingMacroLibRepository : IMasterRepositoryAsync<SewingMacroLib>
    {
        Task<SewingMacroLib> GetSewingMacroLibByIdAsync(int id);
        Task UpdateSewingMacroLibAsync(SewingMacroLib entity, List<SewingMacroLibBOL> insertItems, List<SewingMacroLibBOL> deleteItems);
        Task<SewingMacroLib> AddSewingMacroLibAsync(SewingMacroLib entity);
    }
}
