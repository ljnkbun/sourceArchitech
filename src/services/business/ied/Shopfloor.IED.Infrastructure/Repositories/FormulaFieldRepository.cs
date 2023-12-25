using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class FormulaFieldRepository : GenericRepositoryAsync<FormulaField>, IFormulaFieldRepository
    {
        public FormulaFieldRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsUniqueAsync(string fieldName, int? id = null)
        {
            return await _dbContext.Set<FormulaField>().AllAsync(x => x.FieldName != fieldName || (x.Id == id && x.FieldName == fieldName));
        }
    }
}
