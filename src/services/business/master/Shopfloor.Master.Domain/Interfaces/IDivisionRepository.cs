﻿using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IDivisionRepository : IMasterRepositoryAsync<Division>
    {
        Task<bool> IsExistAsync(int id);
    }
}