using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;
using Shopfloor.Production.Infrastructure.Contexts;

namespace Shopfloor.Production.Infrastructure.Repositories
{
    public class DefectCapturing4PointsRepository : GenericRepositoryAsync<DefectCapturing4Points>, IDefectCapturing4PointsRepository
    {
        public DefectCapturing4PointsRepository(ProductionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
