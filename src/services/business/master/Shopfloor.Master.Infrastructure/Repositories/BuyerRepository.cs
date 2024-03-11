using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class BuyerRepository : GenericRepositoryAsync<Buyer>, IBuyerRepository
    {
        public BuyerRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<bool> IsUniqueAsync(string code, int? id = null)
        {
            return await _dbContext.Set<Buyer>().AllAsync(x => x.WFXBuyerId != code || (x.Id == id && x.WFXBuyerId == code));
        }
    }
}
