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
    public class MaterialRequestRepository : GenericRepositoryAsync<MaterialRequest>, IMaterialRequestRepository
    {
        public MaterialRequestRepository(MaterialContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetMaterialPagedReponseAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<MaterialRequest>().Filter(parameter);
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

        public async Task<bool> UpdateMaterialRequestAsync(MaterialRequest datalUpdate, BaseListCreateDeleteEntity<MOQMSQRoudingOptionItem> dataMoqmsqRoudingOptionItem
            , BaseListCreateDeleteEntity<SupplierWisePurchaseOption> dataSupplierWisePurchaseOption
            , BaseListCreateDeleteEntity<FabricComposition> dataFabricComposition
            , BaseListCreateDeleteEntity<MaterialRequestDynamicColumn> dataMaterialRequestDynamicColumn)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Update(datalUpdate);
                    _dbContext.Set<MOQMSQRoudingOptionItem>().RemoveRange(dataMoqmsqRoudingOptionItem.LstDataDelete);
                    await _dbContext.Set<MOQMSQRoudingOptionItem>().AddRangeAsync(dataMoqmsqRoudingOptionItem.LstDataAdd);
                    _dbContext.Set<SupplierWisePurchaseOption>().RemoveRange(dataSupplierWisePurchaseOption.LstDataDelete);
                    await _dbContext.Set<SupplierWisePurchaseOption>().AddRangeAsync(dataSupplierWisePurchaseOption.LstDataAdd);
                    _dbContext.Set<FabricComposition>().RemoveRange(dataFabricComposition.LstDataDelete);
                    await _dbContext.Set<FabricComposition>().AddRangeAsync(dataFabricComposition.LstDataAdd);
                    _dbContext.Set<MaterialRequestDynamicColumn>().RemoveRange(dataMaterialRequestDynamicColumn.LstDataDelete);
                    await _dbContext.Set<MaterialRequestDynamicColumn>().AddRangeAsync(dataMaterialRequestDynamicColumn.LstDataAdd);
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

        public async Task<List<MaterialRequest>> GetMaterialRequestByIdsAsync(int[] ids)
        {
            return await _dbContext.Set<MaterialRequest>().Include(x => x.MoqmsqRoudingOptionItems)
                .Include(x => x.FabricCompositions)
                .Include(x => x.SupplierWisePurchaseOptions)
                .Include(x => x.DynamicColumns).Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<MaterialRequest> AddMaterialRequestAsync(MaterialRequest entity)
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

        public async Task<MaterialRequest> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<MaterialRequest>()
            .Include(x => x.MoqmsqRoudingOptionItems)
            .Include(x => x.FabricCompositions)
            .Include(x => x.SupplierWisePurchaseOptions)
            .Include(x => x.DynamicColumns)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> AddMaterialRequestRangeAsync(List<MaterialRequest> entities)
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

        private async Task GetNewRequestNoAsync(List<MaterialRequest> entities)
        {
            var autoIncrement = await _dbContext.Set<AutoIncrement>().FirstOrDefaultAsync(x => x.Type == AutoIncrementType.MaterialRequest);
            string inputValue = $"{AutoIncrementType.MaterialRequest}{autoIncrement.Separate}{DateTime.Now:yyyy/MM}";
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
            var autoIncrement = await _dbContext.Set<AutoIncrement>().FirstOrDefaultAsync(x => x.Type == AutoIncrementType.MaterialRequest);
            string inputValue = $"{AutoIncrementType.MaterialRequest}{autoIncrement.Separate}{DateTime.Now:yyyy/MM}";
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
                isUnique = await _dbContext.Set<MaterialRequest>().AllAsync(x => x.RequestNo != requestNo);
                autoIncrement.Index++;
                count++;
            } while (!isUnique && count < 3);
            _dbContext.Set<AutoIncrement>().Update(autoIncrement);
            return requestNo;
        }
    }
}