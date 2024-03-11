using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingSubcategoryEfficiencyRepository : GenericRepositoryAsync<SewingSubcategoryEfficiency>, ISewingSubcategoryEfficiencyRepository
    {
        public SewingSubcategoryEfficiencyRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<SewingSubcategoryEfficiency>().AnyAsync(x => x.Id == id);
        }
        public async Task<bool> IsUniqueSubCategoryAsync(string subCategory, int? id = null)
        {
            return await _dbContext.Set<SewingSubcategoryEfficiency>().AllAsync(x => x.SubCategory != subCategory || (x.Id == id && x.SubCategory == subCategory));
        }
    }
}