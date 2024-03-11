using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class SupplierRepository : GenericRepositoryAsync<Supplier>, ISupplierRepository
    {
        public SupplierRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<bool> IsUniqueAsync(string code, int? id = null)
        {
            return await _dbContext.Set<Supplier>().AllAsync(x => x.WFXSupplierId != code || (x.Id == id && x.WFXSupplierId == code));
        }
    }
}
