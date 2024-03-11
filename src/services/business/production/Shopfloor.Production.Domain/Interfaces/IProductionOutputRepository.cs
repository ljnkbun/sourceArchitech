using Shopfloor.Core.Repositories;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Domain.Interfaces
{
    public interface IProductionOutputRepository : IGenericRepositoryAsync<ProductionOutput>
    {
        Task<ICollection<ProductionOutput>> GetByIdsAsync(int[] ids);
        Task<ProductionOutput> GetDeepByCodeAsync(string code);
        Task<ProductionOutput> GetDeepByIdAsync(int id);
        Task UpdateProductionOuputAsync(ProductionOutput entity, IEnumerable<InspectionBySize> dbBySizeModifieds, IEnumerable<Measurement> dbMesurementModifieds, IEnumerable<DefectCapturing> dbDefectCapturingModifieds, IEnumerable<DefectCapturing4Points> dbDefectCapturing4PointsModifieds, IEnumerable<DefectCapturing100Points> dbDefectCapturing100PointsModifieds);
    }
}
