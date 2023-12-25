using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;
using Shopfloor.Material.Infrastructure.Contexts;

namespace Shopfloor.Material.Infrastructure.Repositories
{
    public class SupplierWisePurchaseOptionRepository : GenericRepositoryAsync<SupplierWisePurchaseOption>, ISupplierWisePurchaseOptionRepository
    {
        public SupplierWisePurchaseOptionRepository(MaterialContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}