using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.IED.Application.Helpers;
using Shopfloor.IED.Domain.Constants;
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
        private readonly IRequestClientService _requestClientService;

        public RequestRepository(IEDContext dbContext, IMapper mapper, IRequestClientService requestClientService) : base(dbContext, mapper)
        {
            _requestSet = _dbContext.Set<Request>();
            _autoIncrementSet = _dbContext.Set<AutoIncrement>();
            _requestClientService = requestClientService;
        }
        public async Task<Request> GetRequestByIdAsync(int id)
        {
            return await _dbContext.Set<Request>()
                .Include(r => r.RequestDivisions)
                    .ThenInclude(p => p.RequestDivisionProcesses)
                        .ThenInclude(o => o.RequestArticleOutputs)
                            .ThenInclude(o => o.RequestArticleInputs)
                .Include(r => r.RequestDivisions)
                    .ThenInclude(p => p.RequestDivisionFiles)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<Request> GetRequestFullRoutingByIdAsync(int id)
        {
            return await _dbContext.Set<Request>()
                .Include(r => r.RequestDivisions)
                    .ThenInclude(p => p.RequestDivisionProcesses)
                    .ThenInclude(o => o.RequestArticleOutputs)
                    .ThenInclude(o => o.RequestArticleInputs)
                .Include(r => r.RequestDivisions)
                    .ThenInclude(p => p.RequestDivisionProcesses)
                    .ThenInclude(o => o.RequestArticleOutputs)
                    .ThenInclude(x => x.SewingIED)
                    .ThenInclude(x => x.SewingRoutings)
                .Include(r => r.RequestDivisions)
                    .ThenInclude(p => p.RequestDivisionProcesses)
                    .ThenInclude(o => o.RequestArticleOutputs)
                    .ThenInclude(x => x.DyeingIED)
                    .ThenInclude(x => x.DyeingRoutings)
                .Include(r => r.RequestDivisions)
                    .ThenInclude(p => p.RequestDivisionProcesses)
                    .ThenInclude(o => o.RequestArticleOutputs)
                    .ThenInclude(x => x.WeavingIED)
                    .ThenInclude(x => x.WeavingRoutings)
                .Include(r => r.RequestDivisions)
                    .ThenInclude(p => p.RequestDivisionProcesses)
                    .ThenInclude(o => o.RequestArticleOutputs)
                    .ThenInclude(x => x.KnittingIED)
                    .ThenInclude(x => x.KnittingRoutings)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<bool> ApproveRequestsAsync(List<int> ids)
        {
            bool anyRequest = await _dbContext.Set<Request>().AnyAsync(r => r.Status == RequestStatus.Pending && ids.Contains(r.Id));
            if (!anyRequest)
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
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex.Message, ex);
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
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
            var autoIncrement = await _autoIncrementSet.FirstOrDefaultAsync(x => x.Type == AutoIncrementType.IER);
            string inputValue = $"{AutoIncrementType.IER}{autoIncrement.Separate}{DateTime.Now:yyMMdd}";
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
                requestNo = AutoIncrementHelper.GetNewCode(inputValue, autoIncrement);
                isUnique = await _requestSet.AllAsync(x => x.RequestNo != requestNo);
                autoIncrement.Index++;
                count++;
            } while (!isUnique && count < 3);
            _autoIncrementSet.Update(autoIncrement);
            return requestNo;
        }

        public async Task<int> SubmitRequestAsync(int id, string requestNo)
        {
            var articles = await GetArticlesAsync(id);
            if (articles == null || !articles.Any())
            {
                throw new ApiException($"Article not found");
            }
            var sewingArticles = articles.Where(a => a.RequestDivisionProcess.RequestDivision.DivisionCode.Equals(DivisionCode.Sewing, StringComparison.CurrentCultureIgnoreCase)).ToList();
            var dyeingArticles = articles.Where(a => a.RequestDivisionProcess.RequestDivision.DivisionCode.Equals(DivisionCode.Dyeing, StringComparison.CurrentCultureIgnoreCase)).ToList();
            var weavingArticles = articles.Where(a => a.RequestDivisionProcess.RequestDivision.DivisionCode.Equals(DivisionCode.Weaving, StringComparison.CurrentCultureIgnoreCase)).ToList();
            var knittingArticles = articles.Where(a => a.RequestDivisionProcess.RequestDivision.DivisionCode.Equals(DivisionCode.Knitting, StringComparison.CurrentCultureIgnoreCase)).ToList();

            var articleIds = articles.Select(a => a.WFXArticleId).ToList();
            var masterArticles = await GetArticlesFromMasterByIdsAsync(articleIds);
            if (masterArticles == null || !masterArticles.Any())
            {
                throw new ApiException($"Article in master service not found");
            }

            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    int createdSewingRequests = await CreateSewingIEDAsync(sewingArticles, masterArticles, requestNo);
                    int createdDyeingRequests = await CreateDyeingIEDAsync(dyeingArticles, masterArticles, requestNo);
                    int createdWeavingRequests = await CreateWeavingIEDAsync(weavingArticles, masterArticles, requestNo);
                    int createdKnittingRequests = await CreateKnittingIEDAsync(knittingArticles, masterArticles, requestNo);
                    int createdRequests = createdSewingRequests + createdDyeingRequests + createdWeavingRequests + createdKnittingRequests;
                    if (createdRequests > 0)
                        await UpdateRequestStatusToPendingAsync(id);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return createdRequests;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex.Message, ex);
                    throw new ApiException($"Submitting failed. {ex.Message} {ex.InnerException?.Message}");
                }
            }
        }

        private async Task<List<RequestArticleOutput>> GetArticlesAsync(int requestId)
        {
            return await _dbContext.Set<RequestArticleOutput>().Where(o => o.RequestDivisionProcess.RequestDivision.RequestId == requestId)
                                                                .Include(o => o.RequestDivisionProcess)
                                                                    .ThenInclude(p => p.RequestDivision)
                                                                .Include(o => o.RequestArticleInputs)
                                                                .ToListAsync();
        }
        private async Task<int> CreateSewingIEDAsync(List<RequestArticleOutput> articles, List<GetArticleByIdResponse> masterArticles, string requestNo)
        {
            if (articles == null || !articles.Any())
            {
                return 0;
            }

            List<SewingIED> entities = new List<SewingIED>();
            int count = 0;
            foreach (var item in articles)
            {
                var masterArticle = masterArticles.FirstOrDefault(m => m.WFXArticleId == item.WFXArticleId);
                if (masterArticle == null)
                {
                    continue;
                }
                count++;
                entities.Add(new SewingIED()
                {
                    RequestNo = requestNo + "-" + count.ToString("D2"),
                    RequestArticleOutputId = item.Id,
                    WFXArticleId = masterArticle.WFXArticleId,
                    ArticleCode = masterArticle.ArticleCode,
                    ArticleName = masterArticle.ArticleName,
                    Buyer = masterArticle.Buyer,
                    StyleRef = masterArticle.BuyerStyleRef,
                    ProductGroup = masterArticle.ProductGroup,
                    SubCategory = masterArticle.ProductSubCategory,
                    Status = Status.New
                });
            }
            await _dbContext.Set<SewingIED>().AddRangeAsync(entities);
            return entities.Count;
        }
        private async Task<int> CreateDyeingIEDAsync(List<RequestArticleOutput> articles, List<GetArticleByIdResponse> masterArticles, string requestNo)
        {
            if (articles == null || !articles.Any())
            {
                return 0;
            }

            List<DyeingIED> entities = new List<DyeingIED>();
            int count = 0;
            foreach (var item in articles)
            {
                var masterArticle = masterArticles.FirstOrDefault(m => m.WFXArticleId == item.WFXArticleId);
                if (masterArticle == null)
                {
                    continue;
                }
                count++;
                var articleInput = item.RequestArticleInputs.FirstOrDefault();
                entities.Add(new DyeingIED()
                {
                    RequestNo = requestNo + "-" + count.ToString("D2"),
                    RequestArticleOutputId = item.Id,
                    WFXArticleId = masterArticle.WFXArticleId,
                    ArticleCode = masterArticle.ArticleCode,
                    ArticleName = masterArticle.ArticleName,
                    Buyer = masterArticle.Buyer,
                    ProductGroup = masterArticle.ProductGroup,
                    SubCategory = masterArticle.ProductSubCategory,
                    TCFNo = (masterArticle.FlexFieldList == null || masterArticle.FlexFieldList.Count == 0) ? null : masterArticle.FlexFieldList.FirstOrDefault(f => f.AttributeName.Equals("TCFNO", StringComparison.CurrentCultureIgnoreCase))?.AttributeValue,
                    WFXInputMaterialId = articleInput?.WFXArticleId,
                    InputMaterialName = articleInput?.ArticleName,
                    Status = Status.New
                });
            }
            await _dbContext.Set<DyeingIED>().AddRangeAsync(entities);
            return entities.Count;
        }
        private async Task<int> CreateWeavingIEDAsync(List<RequestArticleOutput> articles, List<GetArticleByIdResponse> masterArticles, string requestNo)
        {
            if (articles == null || !articles.Any())
            {
                return 0;
            }

            List<WeavingIED> entities = new List<WeavingIED>();
            int count = 0;
            foreach (var item in articles)
            {
                var masterArticle = masterArticles.FirstOrDefault(m => m.WFXArticleId == item.WFXArticleId);
                if (masterArticle == null)
                {
                    continue;
                }
                count++;
                entities.Add(new WeavingIED()
                {
                    RequestNo = requestNo + "-" + count.ToString("D2"),
                    RequestArticleOutputId = item.Id,
                    WFXArticleId = masterArticle.WFXArticleId,
                    ArticleCode = masterArticle.ArticleCode,
                    ArticleName = masterArticle.ArticleName,
                    Buyer = masterArticle.Buyer,
                    ProductGroup = masterArticle.ProductGroup,
                    SubCategory = masterArticle.ProductSubCategory,
                    Status = Status.New
                });
            }
            await _dbContext.Set<WeavingIED>().AddRangeAsync(entities);
            return entities.Count;
        }
        private async Task<int> CreateKnittingIEDAsync(List<RequestArticleOutput> articles, List<GetArticleByIdResponse> masterArticles, string requestNo)
        {
            if (articles == null || !articles.Any())
            {
                return 0;
            }

            List<KnittingIED> entities = new List<KnittingIED>();
            int count = 0;
            foreach (var item in articles)
            {
                var masterArticle = masterArticles.FirstOrDefault(m => m.WFXArticleId == item.WFXArticleId);
                if (masterArticle == null)
                {
                    continue;
                }
                count++;
                entities.Add(new KnittingIED()
                {
                    RequestNo = requestNo + "-" + count.ToString("D2"),
                    RequestArticleOutputId = item.Id,
                    WFXArticleId = masterArticle.WFXArticleId,
                    ArticleCode = masterArticle.ArticleCode,
                    ArticleName = masterArticle.ArticleName,
                    Buyer = masterArticle.Buyer,
                    ProductGroup = masterArticle.ProductGroup,
                    SubCategory = masterArticle.ProductSubCategory,
                    Status = Status.New
                });
            }
            await _dbContext.Set<KnittingIED>().AddRangeAsync(entities);
            return entities.Count;
        }
        private async Task<List<GetArticleByIdResponse>> GetArticlesFromMasterByIdsAsync(List<int> ids)
        {
            var response = await _requestClientService.GetResponseAsync<GetArticlesByIdsRequest, GetArticlesByIdsResponse>(new GetArticlesByIdsRequest
            {
                Ids = ids,
            });
            if (response == null || response.Message == null)
            {
                throw new Exception("Submitting Request: Article not found in master");
            }
            return response.Message.Data;
        }
        private async Task UpdateRequestStatusToPendingAsync(int id)
        {
            var request = await _dbContext.Set<Request>().FindAsync(id);
            if (request == null || request.Status != RequestStatus.Draft)
            {
                throw new Exception("Submitting Request: Cannot change request status");
            }
            request.Status = RequestStatus.Pending;
            _dbContext.Entry(request).State = EntityState.Modified;
        }
    }
}
