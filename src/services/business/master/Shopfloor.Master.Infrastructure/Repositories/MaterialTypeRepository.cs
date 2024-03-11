using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class MaterialTypeRepository : MasterRepositoryAsync<MaterialType>, IMaterialTypeRepository
    {
        private readonly DbSet<MaterialType> _materialTypes;
        private readonly DbSet<CategoryMapMaterialType> _categoryMapMaterialTypes;
        public MaterialTypeRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _materialTypes = _dbContext.Set<MaterialType>();
            _categoryMapMaterialTypes = _dbContext.Set<CategoryMapMaterialType>();
        }
        public async Task<MaterialType> GetMaterialTypeByIdAsync(int id)
        {
            return await _materialTypes
                .Include(x => x.CategoryMapMaterialTypes)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetMaterialTypePagedResponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<MaterialType>().Include(x => x.CategoryMapMaterialTypes).ThenInclude(x => x.Category).AsSingleQuery().Filter(parameter);
            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                .OrderBy(parameter.OrderBy)
                .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                .Paged(parameter.PageSize, parameter.PageNumber)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return response;
        }

        public async Task UpdateMaterialTypeAsync(MaterialType entity, BaseUpdateEntity<CategoryMapMaterialType> categoryMapMaterialTypes)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _dbContext.Set<CategoryMapMaterialType>().RemoveRange(categoryMapMaterialTypes.LstDataDelete);
                _dbContext.Set<CategoryMapMaterialType>().UpdateRange(categoryMapMaterialTypes.LstDataUpdate);
                _dbContext.Set<CategoryMapMaterialType>().AddRange(categoryMapMaterialTypes.LstDataAdd);
                _materialTypes.Update(entity);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }
    }
}
