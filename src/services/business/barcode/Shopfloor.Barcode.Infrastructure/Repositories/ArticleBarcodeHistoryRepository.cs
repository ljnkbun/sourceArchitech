using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ArticleBarcodeHistoryRepository : GenericRepositoryAsync<ArticleBarcodeHistory>, IArticleBarcodeHistoryRepository
    {
        private readonly DbSet<ArticleBarcodeHistory> _articleBarCodeHistorySet;

        public ArticleBarcodeHistoryRepository(BarcodeContext dbContext
            , IMapper mapper
            ) : base(dbContext, mapper)
        {
            _articleBarCodeHistorySet = dbContext.Set<ArticleBarcodeHistory>();
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetModelPagedCustomReponseAsync<TParam, TModel>(TParam parameter, string ids) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);

            var query = _articleBarCodeHistorySet.Filter(parameter);
            if (!string.IsNullOrEmpty(ids))
            {
                var barcodeHisArr = ids.Split(',').Select(x => int.Parse(x.Trim()));
                query = query.Where(x => barcodeHisArr.Contains(x.FromId) || barcodeHisArr.Contains(x.ToId));
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
    }
}
