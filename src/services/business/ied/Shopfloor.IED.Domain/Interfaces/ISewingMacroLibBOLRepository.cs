using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingMacroLibBOLRepository : IGenericRepositoryAsync<SewingMacroLibBOL>
    {
        Task<List<SewingMacroLibBOL>> GetListAsync(int sewingMacroLibId);
    }
}
