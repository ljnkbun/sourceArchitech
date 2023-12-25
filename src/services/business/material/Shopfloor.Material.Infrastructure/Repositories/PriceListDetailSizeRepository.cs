using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;
using Shopfloor.Material.Infrastructure.Contexts;

namespace Shopfloor.Material.Infrastructure.Repositories
{
    public class PriceListDetailSizeRepository : GenericRepositoryAsync<PriceListDetailSize>, IPriceListDetailSizeRepository
    {
        public PriceListDetailSizeRepository(MaterialContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}