using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class DyeingTBMaterialColorRepository : GenericRepositoryAsync<DyeingTBMaterialColor>, IDyeingTBMaterialColorRepository
    {
        public DyeingTBMaterialColorRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DyeingTBMaterialColor>().AnyAsync(x => x.Id == id);
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetMaterialColorPagedResponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<DyeingTBMaterialColor>()
                .Include(x => x.DyeingTBMaterial)
                .ThenInclude(x => x.DyeingTBRequest)
                .Where(x => x.DyeingTBMaterial.DyeingTBRequest.Status != TBRequestStatus.Draft)
                .Filter(parameter);

            if (!string.IsNullOrEmpty(parameter.SearchTerm))
            {
                query = query.Where(x =>
                    x.DyeingTBMaterial != null && (
                        x.DyeingTBMaterial.ArticleCode.Contains(parameter.SearchTerm) ||
                        (x.DyeingTBMaterial.DyeingTBRequest != null &&
                         !x.DyeingTBMaterial.DyeingTBRequest.Deleted &&
                         x.DyeingTBMaterial.DyeingTBRequest.RequestNo.Contains(parameter.SearchTerm))
                    )
                );
            }
            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                .OrderBy(parameter.OrderBy)
                .Paged(parameter.PageSize, parameter.PageNumber)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return response;
        }

        public async Task<DyeingTBMaterialColor> GetWithParentByIdAsync(int id) => await _dbContext.Set<DyeingTBMaterialColor>()
            .Include(x => x.DyeingTBMaterial)
            .ThenInclude(x => x.DyeingTBRequest)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}