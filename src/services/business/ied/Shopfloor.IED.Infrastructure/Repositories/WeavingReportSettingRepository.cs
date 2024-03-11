using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    internal class WeavingReportSettingRepository : GenericRepositoryAsync<WeavingReportSetting>, IWeavingReportSettingRepository
    {
        public WeavingReportSettingRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<WeavingReportSetting>().AnyAsync(x => x.Id == id);
        }
        public async Task<bool> IsExistByWeavingIEDAsync(int weavingIEDId)
        {
            return await _dbContext.Set<WeavingReportSetting>().AnyAsync(x => x.WeavingIEDId == weavingIEDId);
        }

        public async Task<bool> UpdateWeavingReportSettingValueAsync(WeavingReportSetting dataWeavingReportSettingUpdate, BaseUpdateEntity<WeavingReportSettingDetail> dataWeavingReportSettingDetails)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<WeavingReportSettingDetail>().RemoveRange(dataWeavingReportSettingDetails.LstDataDelete);

                    _dbContext.Set<WeavingReportSettingDetail>().UpdateRange(dataWeavingReportSettingDetails.LstDataUpdate);

                    _dbContext.Set<WeavingReportSettingDetail>().AddRange(dataWeavingReportSettingDetails.LstDataAdd);
                    _dbContext.Update(dataWeavingReportSettingUpdate);
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

        public async Task<WeavingReportSetting> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<WeavingReportSetting>()
            .Include(x => x.WeavingReportSettingDetails)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetWeavingReportSettingPagedResponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<WeavingReportSetting>().Include(x => x.WeavingReportSettingDetails).Filter(parameter);
            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                .OrderBy(parameter.OrderBy)
                .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                .Paged(parameter.PageSize, parameter.PageNumber)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return response;
        }
    }
}