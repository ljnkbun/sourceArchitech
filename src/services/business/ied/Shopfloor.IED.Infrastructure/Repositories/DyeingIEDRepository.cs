using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class DyeingIEDRepository : GenericRepositoryAsync<DyeingIED>, IDyeingIEDRepository
    {
        public DyeingIEDRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DyeingIED>().AnyAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetDyeingIEDPagedResponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<DyeingIED>().Where(x => !x.Deleted).Filter(parameter);
            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                .OrderBy(parameter.OrderBy)
                .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                .Paged(parameter.PageSize, parameter.PageNumber)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return response;
        }

        public async Task<DyeingIED> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<DyeingIED>()
            .Include(x => x.DyeingRoutings.OrderBy(r => r.LineNumber))
            .Include(x => x.Recipe)
            .Include(s => s.DyeingFiles)
            .Include(s => s.RequestArticleOutput.RequestDivisionProcess.RequestDivision.RequestDivisionFiles)
            .Include(s => s.RequestArticleOutput)
                .ThenInclude(s => s.RequestArticleInputs)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetSearchDyeingIEDPagedResponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<DyeingIED>()
                .Include(x => x.RequestArticleOutput)
                .ThenInclude(x => x.RequestDivisionProcess)
                .ThenInclude(x => x.RequestDivision)
                .ThenInclude(x => x.Request)
                .Include(x => x.Recipe)
                .Where(x => !x.Deleted).Filter(parameter);

            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                .OrderBy(parameter.OrderBy)
                .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                .Paged(parameter.PageSize, parameter.PageNumber)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return response;
        }
        public async Task UpdateDyeingIEDAsync(DyeingIED dyeingIED, List<DyeingRouting> newDyeingRoutings)
        {
            var newRoutingIds = newDyeingRoutings.Select(l => l.Id);
            var currentRoutings = _dbContext.Set<DyeingRouting>().Where(s => s.DyeingIEDId == dyeingIED.Id);
            var currentRoutingIds = await currentRoutings.Select(r => r.Id).ToListAsync();
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    
                    await currentRoutings.Where(s => !newRoutingIds.Contains(s.Id)).ExecuteDeleteAsync();

                    var newEntities = newDyeingRoutings.Where(e => e.Id == 0);
                    await _dbContext.Set<DyeingRouting>().AddRangeAsync(newEntities);

                    var updateEntities = newDyeingRoutings.Where(e => currentRoutingIds.Contains(e.Id));
                    _dbContext.Set<DyeingRouting>().UpdateRange(updateEntities);

                    _dbContext.Set<DyeingIED>().Update(dyeingIED);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, ex.Message);
                    await transaction.RollbackAsync();
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
                }
            }
        }
    }
}
