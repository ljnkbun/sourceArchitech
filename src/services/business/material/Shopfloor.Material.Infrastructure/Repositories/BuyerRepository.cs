using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
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
    public class BuyerRepository : MasterRepositoryAsync<Buyer>, IBuyerRepository
    {
        private readonly DbSet<Buyer> _buyerSet;
        private readonly DbSet<AutoIncrement> _autoIncrementSet;

        public BuyerRepository(MaterialContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _buyerSet = _dbContext.Set<Buyer>();
            _autoIncrementSet = _dbContext.Set<AutoIncrement>();
        }

        public async Task<Buyer> GetBuyerByIdAsync(int id)
        {
            return await _buyerSet.Include(x => x.ProductCategories).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Buyer>> GetBuyerByIdsAsync(int[] ids)
        {
            return await _buyerSet.Include(x => x.ProductCategories).Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<Buyer> GetBuyerByCodeAsync(string buyerCode)
        {
            return await _buyerSet.Where(x => x.Code == buyerCode).FirstOrDefaultAsync();
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetListAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _buyerSet.Filter(parameter);
            query = query.Where(x => x.Deleted != true);
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

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<BuyerFile>().AnyAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateBuyerAsync(Buyer buyer, List<BuyerProductCategory> insertCategoryMappings, List<BuyerProductCategory> deleteCategoryMappings)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _buyerSet.Update(buyer);
                    if (deleteCategoryMappings is { Count: > 0 })
                        _dbContext.Set<BuyerProductCategory>().RemoveRange(deleteCategoryMappings);
                    if (insertCategoryMappings is { Count: > 0 })
                        await _dbContext.Set<BuyerProductCategory>().AddRangeAsync(insertCategoryMappings);
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

        public async Task<Buyer> AddBuyerAsync(Buyer entity)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    entity.RequestNo = await GetNewRequestNoAsync();
                    await _buyerSet.AddAsync(entity);
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

        public async Task<bool> AddBuyerRangeAsync(List<Buyer> entities)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await GetNewRequestNoAsync(entities);
                    await _buyerSet.AddRangeAsync(entities);
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

        private async Task<string> GetNewRequestNoAsync()
        {
            var autoIncrement = await _autoIncrementSet.FirstOrDefaultAsync(x => x.Type == AutoIncrementType.Buyer);
            string inputValue = $"{AutoIncrementType.Buyer}{autoIncrement.Separate}{DateTime.Now:yyyy/MM}";
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
                isUnique = await _buyerSet.AllAsync(x => x.RequestNo != requestNo);
                autoIncrement.Index++;
                count++;
            } while (!isUnique && count < 3);
            _autoIncrementSet.Update(autoIncrement);
            return requestNo;
        }

        private async Task GetNewRequestNoAsync(List<Buyer> entities)
        {
            var autoIncrement = await _autoIncrementSet.FirstOrDefaultAsync(x => x.Type == AutoIncrementType.Buyer);
            string inputValue = $"{AutoIncrementType.Buyer}{autoIncrement.Separate}{DateTime.Now:yyyy/MM}";
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
            _autoIncrementSet.Update(autoIncrement);
        }
    }
}