using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRecipes
{
    public class ApproveVersionDyeingTBRecipeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int ApproveVersionIndex { get; set; }
    }

    public class ApproveVersionDyeingTBRecipeCommandHandler : IRequestHandler<ApproveVersionDyeingTBRecipeCommand, Response<int>>
    {
        private readonly IDyeingTBRecipeRepository _dyeingTbRecipe;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IDyeingIEDRepository _dyeingIEDRepository;
        private readonly IRequestClientService _requestClientService;


        public ApproveVersionDyeingTBRecipeCommandHandler(IMapper mapper, IDyeingTBRecipeRepository dyeingTbRecipe, IRecipeRepository recipeRepository, IDyeingIEDRepository dyeingIedRepository, IRequestClientService requestClientService)
        {
            _dyeingTbRecipe = dyeingTbRecipe;
            _recipeRepository = recipeRepository;
            _dyeingIEDRepository = dyeingIedRepository;
            _requestClientService = requestClientService;
        }

        public async Task<Response<int>> Handle(ApproveVersionDyeingTBRecipeCommand command, CancellationToken cancellationToken)
        {
            var tasks = new List<Task>();
            var operationLibraryTask = _requestClientService.GetResponseAsync<GetOperationLibrariesRequest, GetOperationLibrariesResponse>(new GetOperationLibrariesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            }, cancellationToken);
            tasks.Add(operationLibraryTask);

            var processesTask = _requestClientService.GetResponseAsync<GetProcessesRequest, GetProcessesResponse>(new GetProcessesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            }, cancellationToken);
            tasks.Add(processesTask);
            await Task.WhenAll(tasks);
            var operationLibraries = operationLibraryTask.Result;
            var processes = processesTask.Result;

            var entity = await _dyeingTbRecipe.GetParentWithIncludeByIdAsync(command.Id);
            if (entity == null) return new($"DyeingTBRecipe Not Found.");
            entity.ApproveVersionIndex = command.ApproveVersionIndex;
            entity.ApproveDate = DateTime.Now;
            await _dyeingTbRecipe.UpdateAsync(entity);
            var result = await _recipeRepository.GetByTBRecipeIdAsync(entity.Id);
            if (result != null) return new($"This TBRecipe was confirmed");
            var recipe = new Recipe
            {
                Color = entity.Color,
                JobDate = DateTime.Now,
                TCFNO = entity.TCFNo,
                Description = entity.TBRecipeName,
                Style = entity.DyeingTBMaterialColor?.DyeingTBMaterial?.DyeingTBRequest?.StyleRef ?? "",
                FabricCode = entity.DyeingTBMaterialColor?.DyeingTBMaterial?.ArticleCode ?? "",
                FabricName = entity.DyeingTBMaterialColor?.DyeingTBMaterial?.ArticleName ?? "",
                RecipeNo = entity.TBRecipeNo,
                DyeingTBRecipeId = entity.Id
            };
            foreach (var entityDyeingTbrTask in entity.DyeingTBRTasks)
            {
                var task = new RecipeTask
                {
                    DyeingOperationCode = operationLibraries.Message.Data.FirstOrDefault(x => x.Id == entityDyeingTbrTask.DyeingOperationId)?.Code,
                    DyeingProcessCode = processes.Message.Data.FirstOrDefault(x => x.Id == entityDyeingTbrTask.DyeingProcessId)?.Code,
                    DyeingProcessId = entityDyeingTbrTask.DyeingProcessId,
                    DyeingProcessName = entityDyeingTbrTask.DyeingProcessName,
                    DyeingOperationId = entityDyeingTbrTask.DyeingOperationId,
                    DyeingOperationName = entityDyeingTbrTask.DyeingOperationName,
                    MachineCode = entityDyeingTbrTask.MachineCode,
                    MachineName = entityDyeingTbrTask.MachineName,
                    Time = entityDyeingTbrTask.Minute,
                    Temperature = entityDyeingTbrTask.Temperature,
                    Ratio = entityDyeingTbrTask.Ratio
                };
                foreach (var dyeingTbrChemical in entityDyeingTbrTask.DyeingTBRChemicals)
                {
                    var chemical = new RecipeChemical
                    {
                        ChemicalCode = dyeingTbrChemical.ChemicalCode,
                        ChemicalName = dyeingTbrChemical.ChemicalName,
                        ChemicalSubcategory = dyeingTbrChemical.ChemicalSubCategory,
                        Unit = dyeingTbrChemical.Unit,
                        Value = dyeingTbrChemical.DyeingTBRChemicalValues.FirstOrDefault(x => x.VersionIndex == command.ApproveVersionIndex)?.Value ?? 0
                    };
                    task.RecipeChemicals.Add(chemical);
                }
                recipe.RecipeTasks.Add(task);
            }
            await _recipeRepository.AddAsync(recipe);
            if (entity.DyeingTBMaterialColor!.DyeingTBMaterial!.DyeingTBRequest!
                    .DyeingIEDId.HasValue)
            {
                var entityDyeing =
                    await _dyeingIEDRepository.GetWithIncludeByIdAsync(entity.DyeingTBMaterialColor!.DyeingTBMaterial!.DyeingTBRequest!
                        .DyeingIEDId.Value);
                entityDyeing.RecipeId = recipe.Id;
                await _dyeingIEDRepository.UpdateAsync(entityDyeing);
            }
            return new Response<int>(recipe.Id);
        }
    }
}