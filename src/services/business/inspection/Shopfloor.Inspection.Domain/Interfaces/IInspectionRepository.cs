using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Domain.Interfaces
{
    public interface IInspectionRepository : IGenericRepositoryAsync<Shopfloor.Inspection.Domain.Entities.Inspection>
    {
        Task<Inspection.Domain.Entities.Inspection> GetInspectionByIdAsync(int id);
        Task<bool> CheckExistInspectionByQCRequestArticleIIdAsync(int id);
        Task UpdateInspectionAsync(Inspection.Domain.Entities.Inspection inspection, IEnumerable<InspectionDefectCapturing> inspectionDefectCapturings,
             IEnumerable<InspectionBySize> inspectionBySizes, IEnumerable<InspectionMesurement> inspectionMesurements);
        Task<Inspection.Domain.Entities.Inspection> GetInspectionWithDetaiḷ(int id);
    }
}
