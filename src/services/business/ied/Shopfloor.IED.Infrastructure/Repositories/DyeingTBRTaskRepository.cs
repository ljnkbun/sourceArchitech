using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    internal class DyeingTBRTaskRepository : GenericRepositoryAsync<DyeingTBRTask>, IDyeingTBRTaskRepository
    {
        public DyeingTBRTaskRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DyeingTBRTask>().AnyAsync(x => x.Id == id);
        }

        public async Task<bool> IsUniqueAsync(string code, int? id = null)
        {
            return await _dbContext.Set<DyeingTBRTask>().AllAsync(x => x.MachineCode != code || (x.Id == id && x.MachineCode == code));
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetTaskPagedResponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<DyeingTBRTask>().Filter(parameter);
            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                .OrderBy(parameter.OrderBy)
                .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                .Paged(parameter.PageSize, parameter.PageNumber)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return response;
        }

        public async Task<bool> UpdateDyeingTBRTaskAsync(DyeingTBRTask dataDyeingTBRTaskUpdate, BaseUpdateEntity<DyeingTBRChemical> dataDyeingTBRChemical, BaseUpdateEntity<DyeingTBRChemicalValue> dataDyeingTBRChemicalValue)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<DyeingTBRChemicalValue>().RemoveRange(dataDyeingTBRChemicalValue.LstDataDelete);
                    _dbContext.Set<DyeingTBRChemical>().RemoveRange(dataDyeingTBRChemical.LstDataDelete);

                    _dbContext.Set<DyeingTBRChemical>().AddRange(dataDyeingTBRChemical.LstDataAdd);
                    _dbContext.Set<DyeingTBRChemicalValue>().AddRange(dataDyeingTBRChemicalValue.LstDataAdd);

                    _dbContext.Update(dataDyeingTBRTaskUpdate);
                    _dbContext.Set<DyeingTBRChemical>().UpdateRange(dataDyeingTBRChemical.LstDataUpdate);
                    _dbContext.Set<DyeingTBRChemicalValue>().UpdateRange(dataDyeingTBRChemicalValue.LstDataUpdate);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    result = false;
                    await transaction.RollbackAsync();
                }
            }
            return result;
        }

        public async Task<DyeingTBRTask> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<DyeingTBRTask>()
            .Include(x => x.DyeingTBRChemicals)
            .ThenInclude(x => x.DyeingTBRChemicalValues)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}