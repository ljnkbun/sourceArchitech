using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class DyeingTBMaterialRepository : GenericRepositoryAsync<DyeingTBMaterial>, IDyeingTBMaterialRepository
    {
        public DyeingTBMaterialRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DyeingTBMaterial>().AnyAsync(x => x.Id == id);
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetMaterialPagedResponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<DyeingTBMaterial>().Filter(parameter);
            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                .OrderBy(parameter.OrderBy)
                .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                .Paged(parameter.PageSize, parameter.PageNumber)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return response;
        }

        public async Task<DyeingTBMaterial> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<DyeingTBMaterial>()
            .Include(x => x.DyeingTBMaterialColors)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}