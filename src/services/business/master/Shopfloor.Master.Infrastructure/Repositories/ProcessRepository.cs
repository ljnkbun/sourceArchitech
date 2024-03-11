using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class ProcessRepository : MasterRepositoryAsync<Process>, IProcessRepository
    {
        public ProcessRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<Process>().AnyAsync(x => x.Id == id);
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetProcessBySubCategoryCodePagedResponseAsync<TParam, TModel>(TParam parameter, string code) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);

            var query = _dbContext.Set<Process>()
                .Include(x => x.SubCategoryGroup)
                .Include(x => x.ProductGroup)
                .Include(x => x.Category)
                .Include(x => x.SubCategory)
                .Where(x => string.IsNullOrEmpty(code) || x.SubCategoryGroup.Code == code)
                .Filter(parameter);

            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                .OrderBy(parameter.OrderBy)
                .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                .Paged(parameter.PageSize, parameter.PageNumber)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return response;
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetProcessByDivisionCodePagedResponseAsync<TParam, TModel>(TParam parameter, string code) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);

            var query = _dbContext.Set<Process>()
                .Include(x => x.SubCategoryGroup)
                .Include(x => x.ProductGroup)
                .Include(x => x.Category)
                .Include(x => x.SubCategory)
                .Include(x => x.Division)
                .Where(x => string.IsNullOrEmpty(code) || x.Division.Code == code)
                .Filter(parameter);

            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                .OrderBy(parameter.OrderBy)
                .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                .Paged(parameter.PageSize, parameter.PageNumber)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return response;
        }

        public async Task<Process> GetProcessInculdeLineMachine(int id)
        {
            return await _dbContext.Set<Process>()
                .Include(x => x.Lines)
                .Include(x => x.Machines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> UpdateWFXProcess(List<Process> newProcess, List<Process> modProcess)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<Process>().AddRangeAsync(newProcess);
                    _dbContext.Set<Process>().UpdateRange(modProcess);
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
    }
}