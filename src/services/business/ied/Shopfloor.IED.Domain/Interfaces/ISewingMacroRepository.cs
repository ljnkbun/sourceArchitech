using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingMacroRepository : IMasterRepositoryAsync<SewingMacro>
    {
        Task<SewingMacro> GetSewingMacroByIdAsync(int id);
        Task UpdateSewingMacroAsync(SewingMacro entity, List<SewingMacroBOL> newSewingMacroBOLs);
    }
}
