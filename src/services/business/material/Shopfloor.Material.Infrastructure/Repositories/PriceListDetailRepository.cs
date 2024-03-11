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
    public class PriceListDetailRepository : GenericRepositoryAsync<PriceListDetail>, IPriceListDetailRepository
    {
        public PriceListDetailRepository(MaterialContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetPriceListDetailPagedReponseAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<PriceListDetail>().Filter(parameter).AsSingleQuery();
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

        public async Task<bool> UpdatePriceListDetailAsync(PriceListDetail dataUpdate
            , BaseUpdateEntity<PriceListDetailColor> dataPriceListDetailColor
            , BaseUpdateEntity<PriceListDetailSize> dataPriceListDetailSize)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Update(dataUpdate);
                    _dbContext.Set<PriceListDetailColor>().RemoveRange(dataPriceListDetailColor.LstDataDelete);
                    await _dbContext.Set<PriceListDetailColor>().AddRangeAsync(dataPriceListDetailColor.LstDataAdd);
                    _dbContext.Set<PriceListDetailSize>().RemoveRange(dataPriceListDetailSize.LstDataDelete);
                    await _dbContext.Set<PriceListDetailSize>().AddRangeAsync(dataPriceListDetailSize.LstDataAdd);
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

        public async Task<List<PriceListDetail>> GetPriceListDetailByIdsAsync(int[] ids)
        {
            return await _dbContext.Set<PriceListDetail>().Include(x => x.PriceListDetailColors).Include(x => x.PriceListDetailSizes).Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<List<PriceListDetail>> GetPriceListDetailByParentIdAsync(int parentId)
        {
            return await _dbContext.Set<PriceListDetail>().Include(x => x.PriceListDetailColors).Include(x => x.PriceListDetailSizes).Where(x => x.PriceListId == parentId).ToListAsync();
        }

        public async Task<PriceListDetail> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<PriceListDetail>()
            .Include(x => x.PriceListDetailSizes)
            .Include(x => x.PriceListDetailColors)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}