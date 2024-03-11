using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Application.Helpers;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;
using Shopfloor.Material.Infrastructure.Contexts;

namespace Shopfloor.Material.Infrastructure.Repositories
{
    public class PriceListRepository : GenericRepositoryAsync<PriceList>, IPriceListRepository
    {
        public PriceListRepository(MaterialContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetPriceListPagedReponseAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<PriceList>().Filter(parameter).AsSingleQuery();
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

        public async Task<bool> UpdatePriceListAsync(PriceList dataUpdate
            , BaseUpdateEntity<PriceListDetail> dataPriceListDetail)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Update(dataUpdate);
                    _dbContext.Set<PriceListDetail>().RemoveRange(dataPriceListDetail.LstDataDelete);
                    await _dbContext.Set<PriceListDetail>().AddRangeAsync(dataPriceListDetail.LstDataAdd);
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

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<PriceList>().AnyAsync(x => x.Id == id);
        }
        
        public async Task<PriceList> AddPriceListAsync(PriceList entity)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    entity.RequestNo = await GetNewRequestNoAsync();
                    await _dbContext.AddAsync(entity);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }
            return entity;
        }

        public async Task<bool> AddPriceListRangeAsync(List<PriceList> entities)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await GetNewRequestNoAsync(entities);
                    await _dbContext.AddRangeAsync(entities);
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

        public async Task<List<PriceList>> GetPriceListByIdsAsync(int[] ids)
        {
            return await _dbContext.Set<PriceList>()
                .Include(x => x.PriceListDetails)
                .ThenInclude(x => x.PriceListDetailSizes)
                .Include(x => x.PriceListDetails)
                .ThenInclude(x => x.PriceListDetailColors)
                .Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<PriceList> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<PriceList>()
            .Include(x => x.PriceListDetails)
            .ThenInclude(x => x.PriceListDetailSizes)
            .Include(x => x.PriceListDetails)
            .ThenInclude(x => x.PriceListDetailColors)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        private async Task GetNewRequestNoAsync(List<PriceList> entities)
        {
            var autoIncrement = await _dbContext.Set<AutoIncrement>().FirstOrDefaultAsync(x => x.Type == AutoIncrementType.PriceList);
            string inputValue = $"{AutoIncrementType.PriceList}{autoIncrement.Separate}{DateTime.Now:yyyy/MM}";
            if (inputValue != autoIncrement.InputValue)
            {
                autoIncrement.Index = 1;
                autoIncrement.InputValue = inputValue;
            }
            foreach (var entity in entities)
            {
                entity.RequestNo = AutoIncrementHelper.GetNewRequestNo(inputValue, autoIncrement);
                autoIncrement.Index++;
            }
            _dbContext.Set<AutoIncrement>().Update(autoIncrement);
        }

        private async Task<string> GetNewRequestNoAsync()
        {
            var autoIncrement = await _dbContext.Set<AutoIncrement>().FirstOrDefaultAsync(x => x.Type == AutoIncrementType.PriceList);
            string inputValue = $"{AutoIncrementType.PriceList}{autoIncrement.Separate}{DateTime.Now:yyyy/MM}";
            if (inputValue != autoIncrement.InputValue)
            {
                autoIncrement.Index = 1;
                autoIncrement.InputValue = inputValue;
            }
            string requestNo = "";
            bool isUnique = false;
            int count = 0;
            do
            {
                requestNo = AutoIncrementHelper.GetNewRequestNo(inputValue, autoIncrement);
                isUnique = await _dbContext.Set<PriceList>().AllAsync(x => x.RequestNo != requestNo);
                autoIncrement.Index++;
                count++;
            } while (!isUnique && count < 3);
            _dbContext.Set<AutoIncrement>().Update(autoIncrement);
            return requestNo;
        }
    }
}