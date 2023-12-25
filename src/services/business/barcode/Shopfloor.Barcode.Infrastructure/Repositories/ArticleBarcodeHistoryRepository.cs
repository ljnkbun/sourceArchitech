using AutoMapper;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ArticleBarcodeHistoryRepository : GenericRepositoryAsync<ArticleBarcodeHistory>, IArticleBarcodeHistoryRepository
    {

        public ArticleBarcodeHistoryRepository(BarcodeContext dbContext
            , IMapper mapper
            ) : base(dbContext, mapper)
        {
        }

    }
}
