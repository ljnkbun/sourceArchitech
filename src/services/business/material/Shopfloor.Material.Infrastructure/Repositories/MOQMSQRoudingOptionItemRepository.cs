using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;
using Shopfloor.Material.Infrastructure.Contexts;

namespace Shopfloor.Material.Infrastructure.Repositories
{
    internal class MOQMSQRoudingOptionItemRepository : GenericRepositoryAsync<MOQMSQRoudingOptionItem>, IMOQMSQRoudingOptionItemRepository
    {
        public MOQMSQRoudingOptionItemRepository(MaterialContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}