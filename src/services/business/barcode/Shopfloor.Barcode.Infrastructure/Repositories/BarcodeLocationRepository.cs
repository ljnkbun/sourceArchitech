using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class BarcodeLocationRepository : GenericRepositoryAsync<BarcodeLocation>, IBarcodeLocationRepository
    {
        public BarcodeLocationRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
