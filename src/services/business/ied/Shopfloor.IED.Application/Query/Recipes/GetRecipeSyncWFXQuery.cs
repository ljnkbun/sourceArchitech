using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Requests.MaterialRequests.DynamicColumns;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Models.Responses.MaterialRequests.DynamicColumns;
using Shopfloor.EventBus.Services;
using Shopfloor.IED.Application.Models.Recipes;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RecipeSyncWFXs
{
    public class GetRecipeSyncWFXQuery : IRequest<Response<RecipeSyncWFXModel>>
    {
        public int DyeingTBRecipeId { get; set; }
    }

    public class GetRecipeSyncWFXQueryHandler : IRequestHandler<GetRecipeSyncWFXQuery, Response<RecipeSyncWFXModel>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IDyeingTBRecipeRepository _dyeingTbRecipeRepository;
        private readonly IRequestClientService _requestClientService;

        public GetRecipeSyncWFXQueryHandler(IRecipeRepository recipeRepository, IDyeingTBRecipeRepository dyeingTbRecipeRepository, IRequestClientService requestClientService)
        {
            _recipeRepository = recipeRepository;
            _dyeingTbRecipeRepository = dyeingTbRecipeRepository;
            _requestClientService = requestClientService;
        }

        public async Task<Response<RecipeSyncWFXModel>> Handle(GetRecipeSyncWFXQuery query, CancellationToken cancellationToken)
        {
            var rs = new RecipeSyncWFXModel();
            var dataRecipe = await _recipeRepository.GetWithIncludeByDyeingTBRecipeIdAsync(query.DyeingTBRecipeId);
            var dataDyeingTBRecipe =
                await _dyeingTbRecipeRepository.GetParentWithIncludeByIdAsync(query.DyeingTBRecipeId);
            var tasks = new List<Task>();
            var dataDynamicColumnsTask =
                _requestClientService.GetResponseAsync<GetDynamicColumnsRequest, GetDynamicColumnsResponse>(
                    new GetDynamicColumnsRequest
                    {
                        PageNumber = 1,
                        PageSize = int.MaxValue,
                        CategoryCode = "Services"
                    }, cancellationToken);
            tasks.Add(dataDynamicColumnsTask);
            var dataProcessesTask = _requestClientService.GetResponseAsync<GetProcessesRequest, GetProcessesResponse>(
                new GetProcessesRequest
                {
                    PageNumber = 1,
                    PageSize = int.MaxValue
                }, cancellationToken);
            tasks.Add(dataProcessesTask);
            var dataOperationsTask =
                _requestClientService
                    .GetResponseAsync<GetOperationLibrariesRequest, GetOperationLibrariesResponse>(
                        new GetOperationLibrariesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
            tasks.Add(dataOperationsTask);
            var dataSubCategoriesTask =
                _requestClientService.GetResponseAsync<GetSubCategoriesRequest, GetSubCategoriesResponse>(
                    new GetSubCategoriesRequest
                    {
                        PageNumber = 1,
                        PageSize = int.MaxValue
                    }, cancellationToken);
            tasks.Add(dataSubCategoriesTask);
            var dataArticlesTask =
                _requestClientService.GetResponseAsync<GetArticlesRequest, GetArticlesResponse>(
                    new GetArticlesRequest
                    {
                        PageNumber = 1,
                        PageSize = int.MaxValue
                    }, cancellationToken);
            tasks.Add(dataArticlesTask);
            await Task.WhenAll(tasks);
            var dataDynamicColumns = dataDynamicColumnsTask.Result;
            var dataArticles = dataArticlesTask.Result;
            var dataSubCategories = dataSubCategoriesTask.Result;
            var dataOperations = dataOperationsTask.Result;
            var dataProcesses = dataProcessesTask.Result;
            rs.header = GetRecipeSyncWfxHeader(dataRecipe, dataDyeingTBRecipe);
            rs.flexfield = GetRecipeSyncWfxFlexField(dataDyeingTBRecipe, dataDynamicColumns.Message.Data);
            rs.Materials = GetRecipeSyncWFXMaterial(dataRecipe, dataDyeingTBRecipe, dataProcesses.Message.Data,
                dataOperations.Message.Data, dataSubCategories.Message.Data, dataArticles.Message.Data);
            rs.waterdetail = new RecipeSyncWFXWaterdetailModel();
            return new Response<RecipeSyncWFXModel>(rs);
        }

        private RecipeSyncWFXHeaderModel GetRecipeSyncWfxHeader(Recipe dataRecipe, DyeingTBRecipe dataDyeingTbRecipe)
        {
            var rs = new RecipeSyncWFXHeaderModel();
            rs.recipedescription = dataDyeingTbRecipe.TBRecipeName;
            rs.color = dataRecipe.Color;
            rs.shade = dataDyeingTbRecipe.Concentration;
            rs.recipecategory_id = dataDyeingTbRecipe.DyeingTBMaterialColor.DyeingTBMaterial.DyeingTBRequest
                .RecipeCategoryId;
            rs.sampleweight = 1;
            rs.liquorratio = 1;
            rs.pickupperc = 1;
            rs.uom = "KGS";
            rs.remarks = dataDyeingTbRecipe.DyeingTBMaterialColor.DyeingTBMaterial.DyeingTBRequest
                .Remark;
            return rs;
        }

        private List<RecipeSyncWFXFlexFieldModel> GetRecipeSyncWfxFlexField(DyeingTBRecipe dataDyeingTbRecipe, List<GetDynamicColumnByIdResponse> dataDynamicColumns)
        {
            var rs = new List<RecipeSyncWFXFlexFieldModel>();
            var dataLights = dataDyeingTbRecipe.DyeingTBMaterialColor.DyeingTBMaterial.Lights.Split(",");
            if (dataDynamicColumns.Count >= dataLights.Length)
            {
                int i = 0;
                foreach (var item in dataLights)
                {
                    rs.Add(new RecipeSyncWFXFlexFieldModel
                    {
                        flexfieldname = dataDynamicColumns[i].Name,
                        flexfieldvalue = item.Trim()
                    });
                    i++;
                }
            }
            return rs;
        }

        private List<RecipeSyncWFXMaterialModel> GetRecipeSyncWFXMaterial(Recipe dataRecipe, DyeingTBRecipe dataDyeingTbRecipe, List<GetProcessByIdResponse> dataProcesses, List<GetOperationLibraryByIdResponse> dataOperationLibraries, List<GetSubCategoryByIdResponse> dataSubCategories, List<GetArticleByIdResponse> dataArticles)
        {
            var rs = new List<RecipeSyncWFXMaterialModel>();
            foreach (var item in dataRecipe.RecipeTasks)
            {
                var dataRecipeSyncWFXMaterial = new RecipeSyncWFXMaterialModel();
                dataRecipeSyncWFXMaterial.temperature = item.Temperature;
                dataRecipeSyncWFXMaterial.timevalue = item.Time;
                dataRecipeSyncWFXMaterial.timeunit = "min";
                dataRecipeSyncWFXMaterial.process_id =
                    dataProcesses.FirstOrDefault(x => x.Id == item.DyeingProcessId)?.WFXProcessId;
                dataRecipeSyncWFXMaterial.materialdetail = new List<RecipeSyncWFXMaterialDetailModel>();
                foreach (var itemRecipeChemical in item.RecipeChemicals)
                {
                    var dataMaterialDetail = new RecipeSyncWFXMaterialDetailModel();
                    dataMaterialDetail.ph = 0;
                    dataMaterialDetail.ratio = item.Ratio;
                    dataMaterialDetail.consumption = itemRecipeChemical.Value;
                    dataMaterialDetail.material_id = dataArticles
                        .FirstOrDefault(x => x.ArticleCode == itemRecipeChemical.ChemicalCode)?.WFXArticleId;
                    dataRecipeSyncWFXMaterial.materialdetail.Add(dataMaterialDetail);
                }
                rs.Add(dataRecipeSyncWFXMaterial);
            }
            return rs;
        }
    }
}