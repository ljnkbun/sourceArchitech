using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class WfxGDIRepository : GenericRepositoryAsync<WfxGDI>, IWfxGDIRepository
    {
        private readonly DbSet<WfxGDI> _wfxGDIs;
        private readonly DbSet<Location> _locations;
        public WfxGDIRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _wfxGDIs = dbContext.Set<WfxGDI>();
            _locations = dbContext.Set<Location>();
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetListAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _wfxGDIs.Filter(parameter);
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.OrderCreationDate.HasValue && x.OrderCreationDate.Value.Date >= fromDate.Value.Date);
            }
            if (toDate.HasValue)
            {
                query = query.Where(x => x.OrderCreationDate.HasValue && x.OrderCreationDate.Value.Date <= toDate.Value.Date);
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

        public async Task<bool> Existed()
        {
            return await _wfxGDIs.AnyAsync();
        }

        public async Task SaveWfxGDISync(List<WfxGDI> entites)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var groupGDINum = entites.GroupBy(x => x.GDINum).Select(x => x.Key);

                var locations = _locations.Where(x => entites.Select(o => o.Location).Contains(x.Name));

                var delEntities = new List<WfxGDI>();

                foreach (var gDINum in groupGDINum)
                {
                    var lstDelByGDINum = await _wfxGDIs.Where(x => x.GDINum == gDINum).ToListAsync();
                    delEntities.AddRange(lstDelByGDINum);
                }

                _wfxGDIs.RemoveRange(delEntities);

                foreach (var e in entites)
                {
                    e.LocationId = locations.FirstOrDefault(x => x.Name == e.Location)?.Id;
                }
                await _wfxGDIs.AddRangeAsync(entites);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.FullMessage());
            }
        }

        public async Task<DateTime> GetLastDate()
        {
            return await _wfxGDIs.MaxAsync(x => x.OrderCreationDate) ?? DateTime.Now;
        }

        public async Task<List<WfxGDI>> GetByArticleCodeOrderRefAsync(string articleCode, string orderRefNum, string gDINum)
        {
            return await _wfxGDIs.Where(x => x.ArticleCode == articleCode && x.OrderRefNum == orderRefNum && x.GDINum == gDINum).ToListAsync();
        }

        public async Task<List<WfxGDI>> GetByArticleCodesAsync(string[] articleCodes)
        {
            return await _wfxGDIs.Where(x => articleCodes.Contains(x.ArticleCode)).ToListAsync();
        }
    }

}
