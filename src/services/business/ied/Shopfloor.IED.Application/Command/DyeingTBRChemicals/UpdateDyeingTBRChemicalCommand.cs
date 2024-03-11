using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DyeingTBRChemicalValues;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRChemicals
{
    public class UpdateDyeingTBRChemicalCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int DyeingTBRTaskId { get; set; }
        public int ChemicalId { get; set; }
        public string ChemicalCode { get; set; }
        public string ChemicalName { get; set; }
        public string ChemicalSubCategory { get; set; }
        public string Unit { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UpdateDyeingTBRChemicalValueCommand> DyeingTBRChemicalValues { get; set; }
    }

    public class UpdateDyeingTBRChemicalCommandHandler : IRequestHandler<UpdateDyeingTBRChemicalCommand, Response<int>>
    {
        private readonly IDyeingTBRChemicalRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDyeingTBRChemicalCommandHandler(IDyeingTBRChemicalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBRChemicalCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(command.Id);

            if (entity == null) return new($"DyeingTBRChemical Not Found.");

            entity.DyeingTBRTaskId = command.DyeingTBRTaskId;
            entity.ChemicalCode = command.ChemicalCode;
            entity.Unit = command.Unit;
            entity.ChemicalName = command.ChemicalName;
            entity.ChemicalId = command.ChemicalId;
            entity.IsActive = command.IsActive;
            entity.ChemicalSubCategory = command.ChemicalSubCategory;

            var dbDyeingTBRChemicalValues = entity.DyeingTBRChemicalValues;

            entity.DyeingTBRChemicalValues = null;

            #region DyeingTBRChemicalValue

            var dbDyeingTBRChemicalValueModifieds = dbDyeingTBRChemicalValues.Where(x => command.DyeingTBRChemicalValues.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(command.DyeingTBRChemicalValues.First(c => c.Id == x.Id), x));

            var newDyeingTBRChemicalValueAddeds = command.DyeingTBRChemicalValues.Where(x => x.Id == 0)
                .Select(x => _mapper.Map<DyeingTBRChemicalValue>(x));

            var dbDyeingTBRChemicalValueDeletes =
                dbDyeingTBRChemicalValues.Where(x => dbDyeingTBRChemicalValueModifieds.All(y => y.Id != x.Id));

            #endregion DyeingTBRChemicalValue

            await _repository.UpdateDyeingTBRChemicalValueAsync(entity, new BaseUpdateEntity<DyeingTBRChemicalValue>()
            {
                LstDataUpdate = dbDyeingTBRChemicalValueModifieds,
                LstDataAdd = newDyeingTBRChemicalValueAddeds,
                LstDataDelete = dbDyeingTBRChemicalValueDeletes
            });
            return new Response<int>(entity.Id);
        }
    }
}