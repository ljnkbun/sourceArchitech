using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Application.Helpers;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class DyeingTBRequestRepository : GenericRepositoryAsync<DyeingTBRequest>, IDyeingTBRequestRepository
    {
        public DyeingTBRequestRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DyeingTBRequest>().AnyAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetRequestPagedResponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<DyeingTBRequest>().Where(x => !x.Deleted).Filter(parameter);
            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                .OrderBy(parameter.OrderBy)
                .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                .Paged(parameter.PageSize, parameter.PageNumber)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return response;
        }

        public async Task<DyeingTBRequest> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<DyeingTBRequest>()
            .Include(x => x.DyeingTBMaterials)
            .ThenInclude(x => x.DyeingTBMaterialColors)
            .Include(x => x.DyeingTBRequestFiles)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);

        public async Task<DyeingTBRequest> AddDyeingTBRequestAsync(DyeingTBRequest entity)
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

        public async Task<bool> UpdateDyeingTBRequestAsync(DyeingTBRequest dataDyeingTBRequestUpdate, BaseUpdateEntity<DyeingTBMaterial> dataDyeingTBMaterial, BaseUpdateEntity<DyeingTBMaterialColor> dataDyeingTBMaterialColor)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<DyeingTBMaterialColor>().RemoveRange(dataDyeingTBMaterialColor.LstDataDelete);
                    _dbContext.Set<DyeingTBMaterial>().RemoveRange(dataDyeingTBMaterial.LstDataDelete);

                    _dbContext.Set<DyeingTBMaterial>().AddRange(dataDyeingTBMaterial.LstDataAdd);
                    _dbContext.Set<DyeingTBMaterialColor>().AddRange(dataDyeingTBMaterialColor.LstDataAdd);

                    _dbContext.Update(dataDyeingTBRequestUpdate);
                    _dbContext.Set<DyeingTBMaterial>().UpdateRange(dataDyeingTBMaterial.LstDataUpdate);
                    _dbContext.Set<DyeingTBMaterialColor>().UpdateRange(dataDyeingTBMaterialColor.LstDataUpdate);
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
            var autoIncrement = await _dbContext.Set<AutoIncrement>().FirstOrDefaultAsync(x => x.Type == AutoIncrementType.RCR);
            string inputValue = $"{AutoIncrementType.RCR}{autoIncrement.Separate}{DateTime.Now:yyMMdd}";
            if (inputValue != autoIncrement.InputValue)
            {
                autoIncrement.Index = 1;
                autoIncrement.InputValue = inputValue;
            }
            string requestNo;
            bool isUnique;
            int count = 0;
            do
            {
                requestNo = AutoIncrementHelper.GetNewCode(inputValue, autoIncrement);
                isUnique = await _dbContext.Set<DyeingTBRequest>().AllAsync(x => x.RequestNo != requestNo);
                autoIncrement.Index++;
                count++;
            } while (!isUnique && count < 3);
            _dbContext.Set<AutoIncrement>().Update(autoIncrement);
            return requestNo;
        }
    }
}