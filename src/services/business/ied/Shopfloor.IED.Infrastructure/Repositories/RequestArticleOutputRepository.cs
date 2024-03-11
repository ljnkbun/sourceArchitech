using AutoMapper;
using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class RequestArticleOutputRepository : GenericRepositoryAsync<RequestArticleOutput>, IRequestArticleOutputRepository
    {
        public RequestArticleOutputRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<RequestArticleOutput>().AnyAsync(x => x.Id == id);
        }

        public async Task<RequestArticleOutput> GetRequestArticleOutputByIdAsync(int id)
        {
            return await _dbContext.Set<RequestArticleOutput>()
                                    .Include(p => p.RequestArticleInputs)
                                    .FirstOrDefaultAsync(r => r.Id == id);
        }

        private async Task<int> GetRequestIdAsync(int articleId)
        {
            return await _dbContext.Set<RequestArticleOutput>()
                                    .Include(x => x.RequestDivisionProcess.RequestDivision)
                                    .FirstOrDefaultAsync(x => x.Id == articleId)
                                    .Select(s => s.RequestDivisionProcess.RequestDivision.RequestId);
        }

        public async Task UpdateStatusAnalyzeArticleAsync(RequestArticleOutput article, DivisionType divisionType)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<RequestArticleOutput>().Update(article);
                    await UpdateRequestOfDivisionAsync(article.Id, divisionType, Status.InProgress, null);
                    await AnalyzeRequestAsync(await GetRequestIdAsync(article.Id));
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex.Message, ex);
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
                }
            }
        }
        public async Task UpdateRequestOfDivisionAsync(int articleId, DivisionType divisionType, Status status, string rejectReason)
        {
            switch (divisionType) {
                case DivisionType.Sewing:
                    await UpdateRequestOfDivisionStatusAsync<SewingIED>(articleId, status, rejectReason);
                    break;
                case DivisionType.Dyeing:
                    await UpdateRequestOfDivisionStatusAsync<DyeingIED>(articleId, status, rejectReason);
                    break;
                case DivisionType.Weaving:
                    await UpdateRequestOfDivisionStatusAsync<WeavingIED>(articleId, status, rejectReason);
                    break;
                case DivisionType.Knitting: 
                    await UpdateRequestOfDivisionStatusAsync<KnittingIED>(articleId, status, rejectReason);
                    break;
            }
        }

        private async Task UpdateRequestOfDivisionStatusAsync<T>(int articleId, Status status, string rejectReason) where T : DivisionIED
        {
            var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(t => t.RequestArticleOutputId == articleId);
            if (entity == null)
                throw new Exception($"Request of Division Not found. RequestArticleOutputId: {articleId}");

            entity.Status = status;
            if(rejectReason != null)
                entity.RejectReason = rejectReason;

            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AnalyzeRequestAsync(int id)
        {
            var entity = await _dbContext.Set<Request>().FindAsync(id);
            if (entity.Status == RequestStatus.Approved || entity.Status == RequestStatus.TransferredToWFX)
                throw new Exception("The Status of Request cannot be change to InProgress");
            if (entity.Status == RequestStatus.InProgress) return;

            entity.Status = RequestStatus.InProgress;
            _dbContext.Set<Request>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateStatusSubmitArticleAsync(RequestArticleOutput article, DivisionType divisionType)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<RequestArticleOutput>().Update(article);
                    await UpdateRequestOfDivisionAsync(article.Id, divisionType, Status.Waiting, null);
                    await SubmitRequestIfAllArticlesBeSubmittedAsync(await GetRequestIdAsync(article.Id), article.Id);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex.Message, ex);
                    throw new ApiException($"Submiting failed. {ex.InnerException?.Message}");
                }
            }
        }
        public async Task SubmitRequestIfAllArticlesBeSubmittedAsync(int requestId, int articleId)
        {
            if (await AllArticlesOnStatus(Status.Waiting, requestId, articleId))
            {
                var entity = await _dbContext.Set<Request>().FindAsync(requestId);
                if (entity.Status == RequestStatus.Approved || entity.Status == RequestStatus.TransferredToWFX)
                    throw new Exception("The Status of Request cannot be change to Waiting");
                if (entity.Status == RequestStatus.Waiting) return;

                entity.Status = RequestStatus.Waiting;
                _dbContext.Set<Request>().Update(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task UpdateStatusApproveArticleAsync(RequestArticleOutput article, DivisionType divisionType)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<RequestArticleOutput>().Update(article);
                    await UpdateRequestOfDivisionAsync(article.Id, divisionType, Status.Approved, String.Empty);
                    await ApproveRequestIfAllArticlesBeApprovedAsync(await GetRequestIdAsync(article.Id), article.Id);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex.Message, ex);
                    throw new ApiException($"Approving failed. {ex.InnerException?.Message}");
                }
            }
        }
        public async Task ApproveRequestIfAllArticlesBeApprovedAsync(int requestId, int articleId)
        {
            if (await AllArticlesOnStatus(Status.Approved, requestId, articleId))
            {
                var entity = await _dbContext.Set<Request>().FindAsync(requestId);
                if (entity.Status == RequestStatus.TransferredToWFX)
                    throw new Exception("The Status of Request cannot be change to Approved");
                if (entity.Status == RequestStatus.Approved) return;

                entity.Status = RequestStatus.Approved;
                _dbContext.Set<Request>().Update(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
        private async Task<bool> AllArticlesOnStatus(Status status, int requestId, int excludedArticleId)
        {
            var request = await _dbContext.Set<Request>()
                                            .Include(r => r.RequestDivisions)
                                                .ThenInclude(d => d.RequestDivisionProcesses)
                                                    .ThenInclude(p => p.RequestArticleOutputs)
                                            .FirstOrDefaultAsync(r => r.Id == requestId);
            if (request == null)
                return false;

            return request.RequestDivisions.All(d => d.RequestDivisionProcesses
                                                .All(p => p.RequestArticleOutputs.Where(p => p.Id != excludedArticleId)
                                                    .All(p => p.Status == status || p.Status == Status.Approved)));
        }

        public async Task UpdateStatusRejectArticleAsync(RequestArticleOutput article, DivisionType divisionType, string rejectReason)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<RequestArticleOutput>().Update(article);
                    await UpdateRequestOfDivisionAsync(article.Id, divisionType, Status.InProgress, rejectReason);
                    await ChangeStatusRequestToInProgressAsync(await GetRequestIdAsync(article.Id));
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex.Message, ex);
                    throw new ApiException($"Rejecting failed. {ex.InnerException?.Message}");
                }
            }
        }
        public async Task ChangeStatusRequestToInProgressAsync(int requestId)
        {
            var entity = await _dbContext.Set<Request>().FindAsync(requestId);
            if (entity.Status == RequestStatus.Approved || entity.Status == RequestStatus.TransferredToWFX)
                throw new Exception("The Status of Request cannot be change to InProgress");
            if (entity.Status == RequestStatus.InProgress) return;

            entity.Status = RequestStatus.InProgress;
            _dbContext.Set<Request>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
