﻿using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IBarcodeLocationRepository : IGenericRepositoryAsync<BarcodeLocation>
    {
    }
}
