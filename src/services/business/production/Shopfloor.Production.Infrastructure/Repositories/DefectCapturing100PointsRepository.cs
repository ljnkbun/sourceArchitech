using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;
using Shopfloor.Production.Infrastructure.Contexts;

namespace Shopfloor.Production.Infrastructure.Repositories
{
    public class DefectCapturing100PointsRepository : GenericRepositoryAsync<DefectCapturing100Points>, IDefectCapturing100PointsRepository
    {
        public DefectCapturing100PointsRepository(ProductionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
