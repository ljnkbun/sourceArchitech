using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface IFPPORepository : IGenericRepositoryAsync<FPPO>
    {
        Task<FPPO> GetFPPOByIdAsync(int id);
        Task UpdateFPPOAsync(FPPO entity, ICollection<FPPODetail> details);
    }
}
