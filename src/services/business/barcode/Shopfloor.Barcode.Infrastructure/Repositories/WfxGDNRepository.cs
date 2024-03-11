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
    public class WfxGDNRepository : GenericRepositoryAsync<WfxGDN>, IWfxGDNRepository
    {
        private readonly DbSet<WfxGDN> _wfxGDNs;
        private readonly DbSet<Location> _locations;
        public WfxGDNRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _wfxGDNs = dbContext.Set<WfxGDN>();
            _locations = dbContext.Set<Location>();
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetListAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _wfxGDNs.Filter(parameter);
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.GDNCreationDate.HasValue && x.GDNCreationDate.Value.Date >= fromDate.Value.Date);
            }
            if (toDate.HasValue)
            {
                query = query.Where(x => x.GDNCreationDate.HasValue && x.GDNCreationDate.Value.Date <= toDate.Value.Date);
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
            return await _wfxGDNs.AnyAsync();
        }

        public async Task SaveWfxGDNSync(List<WfxGDN> entites)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var groupGDNNum = entites.GroupBy(x => x.GDNNum).Select(x => x.Key);

                var locations = _locations.Where(x => entites.Select(o => o.Location).Contains(x.Name));

                var delEntities = new List<WfxGDN>();

                foreach (var GDNNum in groupGDNNum)
                {
                    var lstDelByGDNNum = await _wfxGDNs.Where(x => x.GDNNum == GDNNum).ToListAsync();
                    delEntities.AddRange(lstDelByGDNNum);
                }

                foreach (var e in entites)
                {
                    e.LocationId = locations.FirstOrDefault(x => x.Name == e.Location)?.Id;
                }

                _wfxGDNs.RemoveRange(delEntities);
                await _wfxGDNs.AddRangeAsync(entites);

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
            return await _wfxGDNs.MaxAsync(x => x.GDNCreationDate) ?? DateTime.Now;
        }

        public async Task<List<WfxGDN>> GetByArticleCodeGDNNumAsync(string wfxArticleCode, string GDNNum)
        {
            return await _wfxGDNs.Where(x => x.WFXArticleCode == wfxArticleCode && x.GDNNum == GDNNum).ToListAsync();
        }
    }

}
