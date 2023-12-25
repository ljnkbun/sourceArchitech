﻿using Shopfloor.Core.Repositories;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Domain.Interfaces
{
    public interface ITestEntityRepository : IGenericRepositoryAsync<TestEntity>
    {
    }
}
