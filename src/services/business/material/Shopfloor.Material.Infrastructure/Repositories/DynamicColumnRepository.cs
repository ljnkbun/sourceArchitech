using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;
using Shopfloor.Material.Infrastructure.Contexts;

namespace Shopfloor.Material.Infrastructure.Repositories
{
    public class DynamicColumnRepository : GenericRepositoryAsync<DynamicColumn>, IDynamicColumnRepository
    {
        public DynamicColumnRepository(MaterialContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetDynamicColumnPagedReponseAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<DynamicColumn>().Filter(parameter).AsSingleQuery();
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.CreatedDate.HasValue && x.CreatedDate.Value.Date >= fromDate.Value.Date);
            }
            if (toDate.HasValue)
            {
                query = query.Where(x => x.CreatedDate.HasValue && x.CreatedDate.Value.Date <= toDate.Value.Date);
            }

            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                .OrderBy(parameter.OrderBy)
                .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                .Paged(parameter.PageSize, parameter.PageNumber)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return response;
        }

        public async Task<bool> UpdateDynamicColumnAsync(DynamicColumn datalUpdate
            , BaseListCreateDeleteEntity<DynamicColumnContent> dataDynamicColumnContent)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Update(datalUpdate);
                    _dbContext.Set<DynamicColumnContent>().RemoveRange(dataDynamicColumnContent.LstDataDelete);
                    await _dbContext.Set<DynamicColumnContent>().AddRangeAsync(dataDynamicColumnContent.LstDataAdd);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    result = false;
                    await transaction.RollbackAsync();
                }
            }
            return result;
        }

        public async Task<bool> IsUniqueAsync(string code, string category, int? id = null)
        {
            return !(await _dbContext.Set<DynamicColumn>().AnyAsync(x => x.Code == code && x.CategoryCode == category || (x.Id == id && x.Code == code && x.CategoryCode == category)));
        }

        public async Task<List<DynamicColumn>> GetDynamicColumnByCodesAsync(string[] codes, string type)
        {
            return await _dbContext.Set<DynamicColumn>().Include(x => x.DynamicColumnContents)
                .Include(x => x.MaterialRequestDynamicColumns)
                .Where(x => codes.Contains(x.Code) && x.CategoryCode.ToLower() == type.ToLower())
                .ToListAsync();
        }

        public async Task<List<DynamicColumn>> GetListByCodeAsync(Dictionary<string, string> data, string type)
        {
            var dynamicColumns = await _dbContext.Set<DynamicColumn>().Where(x => x.CategoryCode.ToLower() == type.ToLower()).Include(x => x.DynamicColumnContents).ToListAsync();
            var res = new List<DynamicColumn>();
            foreach (var dynamicColumn in dynamicColumns)
            {
                var valueData = data.GetValueOrDefault(dynamicColumn.Code);
                if (!string.IsNullOrEmpty(valueData))
                {
                    if (dynamicColumn.IsContent)
                    {
                        if (dynamicColumn.DynamicColumnContents.Any(x => x.Content.Equals(valueData)))
                        {
                            res.Add(dynamicColumn);
                        }
                    }
                    else
                    {
                        res.Add(dynamicColumn);
                    }
                }
            }
            return res;
        }

        public async Task<DynamicColumn> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<DynamicColumn>()
            .Include(x => x.DynamicColumnContents)
            .Include(x => x.MaterialRequestDynamicColumns)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}