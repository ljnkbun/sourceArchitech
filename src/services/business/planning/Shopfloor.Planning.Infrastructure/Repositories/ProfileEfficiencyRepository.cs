using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class ProfileEfficiencyRepository : MasterRepositoryAsync<ProfileEfficiency>, IProfileEfficiencyRepository
    {
        private readonly DbSet<ProfileEfficiency> _profileEfficiencies;
        private readonly DbSet<ProfileEfficiencyDetail> _profileEfficiencyDetails;
        public ProfileEfficiencyRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _profileEfficiencies = _dbContext.Set<ProfileEfficiency>();
            _profileEfficiencyDetails = _dbContext.Set<ProfileEfficiencyDetail>();
        }

        public override async Task<ProfileEfficiency> GetByIdAsync(int id)
        {
            return await _profileEfficiencies.Include(x => x.ProfileEfficiencyDetails).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<decimal> GetProfileEfficiencyValueAsync(string category, string productGroup, string subCategory)
        {
            var profileEfficiencyValue = await _profileEfficiencyDetails.FirstOrDefaultAsync(x => x.ProfileEfficiency.CategoryCode == category &&
                                                                                      x.ProfileEfficiency.ProductGroupCode == productGroup &&
                                                                                      x.SubCategoryCode == subCategory);
            return profileEfficiencyValue?.EfficiencyValue ?? 1M;
        }

        public async Task<ProfileEfficiency> GetProfileEfficiencyByIdAsync(int? id = null)
        {
            return await _profileEfficiencies.Include(x => x.ProfileEfficiencyDetails)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetProfileEfficiencyModelAsync<TParam, TModel>(TParam parameter)
            where TParam : RequestParameter
            where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _profileEfficiencies.Filter(parameter);
            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                    .OrderBy(parameter.OrderBy)
                    .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                    .Paged(parameter.PageSize, parameter.PageNumber)
                    .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                    .AsSingleQuery()
                    .ToListAsync();
            return response;
        }

        public async Task UpdateProfileEfficiencyAsync(ProfileEfficiency profileEfficiency, IEnumerable<ProfileEfficiencyDetail> profileEfficiencyDetail)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _profileEfficiencies.Update(profileEfficiency);
                _profileEfficiencyDetails.UpdateRange(profileEfficiencyDetail);

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
