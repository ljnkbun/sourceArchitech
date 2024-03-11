using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;
using static MassTransit.Util.ChartTable;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class MachineRepository : MasterRepositoryAsync<Machine>, IMachineRepository
    {
        private readonly DbSet<Machine> _machines;
        public MachineRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _machines = dbContext.Set<Machine>();
        }

        public async Task<ICollection<Machine>> GetMachineByIdsAsync(List<int> ids)
        {
            return await _machines.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
