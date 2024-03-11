using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DyeingTBRChemicalValues;
using Shopfloor.IED.Application.Command.DyeingTBRTasks;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRecipes
{
    public class UpdateDyeingTBRecipeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int DyeingTBMaterialColorId { get; set; }

        public int TemplateId { get; set; }

        public string TBRecipeName { get; set; }

        public string TemplateName { get; set; }

        public string TCFNo { get; set; }

        public int ApproveVersionIndex { get; set; }

        public DateTime? ApproveDate { get; set; }

        public string Comment { get; set; }

        public string Buyer { get; set; }

        public string BuyerRef { get; set; }

        public string GarmentStyleRef { get; set; }

        public DateTime ExpectedDate { get; set; }

        public string Color { get; set; }

        public string Concentration { get; set; }

        public int VersionQty { get; set; }

        public TBRecipeStatus Status { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UpdateDyeingTBRTaskCommand> DyeingTBRTasks { get; set; }
    }

    public class UpdateDyeingTBRecipeCommandHandler : IRequestHandler<UpdateDyeingTBRecipeCommand, Response<int>>
    {
        private readonly IDyeingTBRecipeRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDyeingTBRecipeCommandHandler(IDyeingTBRecipeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBRecipeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(command.Id);
            if (entity == null) return new($"DyeingTBRecipe Not Found.");
            entity.DyeingTBMaterialColorId = command.DyeingTBMaterialColorId;
            entity.TemplateId = command.TemplateId;
            entity.TemplateName = command.TemplateName;
            entity.TCFNo = command.TCFNo;
            entity.IsActive = command.IsActive;
            entity.ApproveVersionIndex = command.ApproveVersionIndex;
            entity.ApproveDate = command.ApproveDate;
            entity.Comment = command.Comment;
            entity.Buyer = command.Buyer;
            entity.BuyerRef = command.BuyerRef;
            entity.GarmentStyleRef = command.GarmentStyleRef;
            entity.ExpectedDate = command.ExpectedDate;
            entity.Color = command.Color;
            entity.Concentration = command.Concentration;
            entity.VersionQty = command.VersionQty;
            entity.Status = command.Status;
            entity.TBRecipeName = command.TBRecipeName;
            #region Task
            var dbDyeingTBRChemicalValues = entity.DyeingTBRTasks
                .SelectMany(x => x.DyeingTBRChemicals)
                .SelectMany(x => x.DyeingTBRChemicalValues).ToList();
            var dbDyeingTBRChemicals = entity.DyeingTBRTasks.SelectMany(x => x.DyeingTBRChemicals).Select(x =>
            {
                x.DyeingTBRChemicalValues = null;
                return x;
            }).ToList();
            var dbDyeingTBRTasks = entity.DyeingTBRTasks.Select(x =>
            {
                x.DyeingTBRChemicals = null;
                return x;
            }).ToList();

            var commandDyeingTBRChemicalValues = command.DyeingTBRTasks
                .SelectMany(x => x.DyeingTBRChemicals)
                .SelectMany(x => x.DyeingTBRChemicalValues).ToList();
            var commandDyeingTBRChemicals = command.DyeingTBRTasks.SelectMany(x => x.DyeingTBRChemicals).ToList();
            var commandDyeingTBRTasks = command.DyeingTBRTasks.ToList();

            entity.DyeingTBRTasks = null;

            #region DyeingTBRTask

            var dbDyeingTBRTaskModifieds = dbDyeingTBRTasks.Where(x => commandDyeingTBRTasks.Any(y => y.Id == x.Id)).Select(
                x =>
                {
                    var data = _mapper.Map(commandDyeingTBRTasks.First(c => c.Id == x.Id), x);
                    data.DyeingTBRChemicals = null;
                    return data;
                });

            var newDyeingTBRTaskAddeds = commandDyeingTBRTasks.Where(x => x.Id == 0 && x.DyeingTBRecipeId != 0)
                .Select(x => _mapper.Map<DyeingTBRTask>(x));

            var dbDyeingTBRTaskDeletes =
                dbDyeingTBRTasks.Where(x => dbDyeingTBRTaskModifieds.All(y => y.Id != x.Id));

            #endregion DyeingTBRTask

            #region DyeingTBRChemical

            var dbDyeingTBRChemicalModifieds = dbDyeingTBRChemicals.Where(x => commandDyeingTBRChemicals.Any(y => y.Id == x.Id)).Select(
                x =>
                {
                    var data = _mapper.Map(commandDyeingTBRChemicals.First(c => c.Id == x.Id), x);
                    data.DyeingTBRChemicalValues = null;
                    return data;
                });

            var newDyeingTBRChemicalAddeds = commandDyeingTBRChemicals.Where(x => x.Id == 0 && x.DyeingTBRTaskId != 0)
                .Select(x => _mapper.Map<DyeingTBRChemical>(x));

            var dbDyeingTBRChemicalDeletes =
                dbDyeingTBRChemicals.Where(x => dbDyeingTBRChemicalModifieds.All(y => y.Id != x.Id));

            #endregion DyeingTBRChemical

            #region DyeingTBRChemicalValue

            var dbDyeingTBRChemicalValueModifieds = dbDyeingTBRChemicalValues.Where(x => commandDyeingTBRChemicalValues.Any(y => y.Id == x.Id)).Select(
                x => _mapper.Map(commandDyeingTBRChemicalValues.First(c => c.Id == x.Id), x));

            var newDyeingTBRChemicalValueAddeds = commandDyeingTBRChemicalValues.Where(x => x.Id == 0 && x.DyeingTBRChemicalId != 0)
                .Select(x => _mapper.Map<DyeingTBRChemicalValue>(x));

            var dbDyeingTBRChemicalValueDeletes =
                dbDyeingTBRChemicalValues.Where(x => dbDyeingTBRChemicalValueModifieds.All(y => y.Id != x.Id));

            #endregion DyeingTBRChemicalValue

            #endregion Task

            await _repository.UpdateDyeingTBRecipeAsync(entity, new BaseUpdateEntity<DyeingTBRTask>
            {
                LstDataUpdate = dbDyeingTBRTaskModifieds,
                LstDataAdd = newDyeingTBRTaskAddeds,
                LstDataDelete = dbDyeingTBRTaskDeletes
            }, new BaseUpdateEntity<DyeingTBRChemical>
            {
                LstDataUpdate = dbDyeingTBRChemicalModifieds,
                LstDataAdd = newDyeingTBRChemicalAddeds,
                LstDataDelete = dbDyeingTBRChemicalDeletes
            }, new BaseUpdateEntity<DyeingTBRChemicalValue>()
            {
                LstDataUpdate = dbDyeingTBRChemicalValueModifieds,
                LstDataAdd = newDyeingTBRChemicalValueAddeds,
                LstDataDelete = dbDyeingTBRChemicalValueDeletes
            });
            return new Response<int>(entity.Id);
        }
    }
}