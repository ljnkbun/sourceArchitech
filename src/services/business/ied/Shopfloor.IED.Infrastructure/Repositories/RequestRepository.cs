using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Application.Helpers;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class RequestRepository : GenericRepositoryAsync<Request>, IRequestRepository
    {
        private readonly DbSet<Request> _requestSet;
        private readonly DbSet<AutoIncrement> _autoIncrementSet;
        public RequestRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _requestSet = _dbContext.Set<Request>();
            _autoIncrementSet = _dbContext.Set<AutoIncrement>();
        }
        public async Task<Request> GetRequestByIdAsync(int id)
        {
            return await _dbContext.Set<Request>()
                .Include(r => r.RequestDivisions)
                    .ThenInclude(p => p.RequestDivisionProcesses)
                        .ThenInclude(o => o.RequestArticleOutputs)
                            .ThenInclude(o => o.RequestArticleInputs)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> ApproveRequestsAsync(List<int> ids)
        {
            bool anyRequest = await _dbContext.Set<Request>().AnyAsync(r => r.Status == RequestStatus.Pending && ids.Contains(r.Id));
            if(!anyRequest)
                return false;

            await _dbContext.Set<Request>().Where(r => r.Status == RequestStatus.Pending && ids.Contains(r.Id))
                                                .ExecuteUpdateAsync(s => s.SetProperty(o => o.Status, RequestStatus.Approved));
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task UpdateRequestAsync(Request request, List<RequestDivision> insertRequestDivisions, List<RequestDivision> deleteRequestDivisions)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (deleteRequestDivisions != null && deleteRequestDivisions.Count > 0)
                    {
                        _dbContext.Set<RequestDivision>().RemoveRange(deleteRequestDivisions);
                    }
                    if (insertRequestDivisions != null && insertRequestDivisions.Count > 0)
                    {
                        await _dbContext.Set<RequestDivision>().AddRangeAsync(insertRequestDivisions);
                    }
                    _dbContext.Set<Request>().Update(request);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ApiException($"Updating failed.");
                }
            }
        }

        public async Task<Request> AddRequestAsync(Request entity)
        {
            entity.RequestNo = await GetNewRequestNoAsync();
            await _requestSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        private async Task<string> GetNewRequestNoAsync()
        {
            var autoIncrement = await _autoIncrementSet.FirstOrDefaultAsync(x => x.Type == AutoIncrementType.Request);
            string inputValue = $"{AutoIncrementType.Request}{autoIncrement.Separate}{DateTime.Now:yyyy/MM}";
            if (inputValue != autoIncrement.InputValue)
            {
                autoIncrement.Index = 1;
                autoIncrement.InputValue = inputValue;
            }
            string requestNo = "";
            bool isUnique = false;
            int count = 0;
            do
            {
                requestNo = AutoIncrementHelper.GetNewRequestNo(inputValue, autoIncrement);
                isUnique = await _requestSet.AllAsync(x => x.RequestNo != requestNo);
                autoIncrement.Index++;
                count++;
            } while (!isUnique && count < 3);
            _autoIncrementSet.Update(autoIncrement);
            return requestNo;
        }
    }
}
