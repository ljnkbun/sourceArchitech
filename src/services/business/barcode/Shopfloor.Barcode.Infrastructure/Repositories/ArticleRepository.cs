using AutoMapper;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ArticleRepository : MasterRepositoryAsync<Article>, IArticleRepository
    {
        public ArticleRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
