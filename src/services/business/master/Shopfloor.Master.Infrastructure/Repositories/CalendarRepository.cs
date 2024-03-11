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
    public class CalendarRepository : MasterRepositoryAsync<Calendar>, ICalendarRepository
    {
        private readonly DbSet<Calendar> _calendars;
        private readonly DbSet<CalendarDetail> _calendarDetails;
        public CalendarRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _calendars = _dbContext.Set<Calendar>();
            _calendarDetails = _dbContext.Set<CalendarDetail>();
        }
        public override async Task<Calendar> GetByIdAsync(int id)
        {
            return await _calendars.Include(x => x.CalendarDetails).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Calendar>> GetByIds(List<int> ids)
        {
            return await _calendars.Include(x => x.CalendarDetails).Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetCalendarModelAsync<TParam, TModel>(TParam parameter)
            where TParam : RequestParameter
            where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _calendars.Filter(parameter);
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

        public async Task UpdateProfileEfficiencyAsync(Calendar calendar, IEnumerable<CalendarDetail> calendarDetails)
        {

            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _calendars.Update(calendar);
                _calendarDetails.UpdateRange(calendarDetails);

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
