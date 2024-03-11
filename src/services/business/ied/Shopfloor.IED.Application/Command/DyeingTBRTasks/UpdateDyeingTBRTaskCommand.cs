using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DyeingTBRChemicals;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRTasks
{
    public class UpdateDyeingTBRTaskCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public int DyeingTBRecipeId { get; set; }
        public int DyeingProcessId { get; set; }
        public string DyeingProcessName { get; set; }
        public int DyeingOperationId { get; set; }
        public string DyeingOperationName { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public decimal Temperature { get; set; }
        public int Minute { get; set; }
        public decimal Ratio { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UpdateDyeingTBRChemicalCommand> DyeingTBRChemicals { get; set; }
    }

    public class UpdateDyeingTBRTaskCommandHandler : IRequestHandler<UpdateDyeingTBRTaskCommand, Response<int>>
    {
        private readonly IDyeingTBRTaskRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDyeingTBRTaskCommandHandler(IDyeingTBRTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBRTaskCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(command.Id);
            if (entity == null) return new($"DyeingTBRTask Not Found.");
            entity.LineNumber = command.LineNumber;
            entity.DyeingTBRecipeId = command.DyeingTBRecipeId;
            entity.DyeingOperationName = command.DyeingOperationName;
            entity.DyeingOperationId = command.DyeingOperationId;
            entity.DyeingProcessName = command.DyeingProcessName;
            entity.DyeingProcessId = command.DyeingProcessId;
            entity.MachineCode = command.MachineCode;
            entity.MachineName = command.MachineName;
            entity.Temperature = command.Temperature;
            entity.Minute = command.Minute;
            entity.IsActive = command.IsActive;
            entity.Ratio = command.Ratio;

            var dbDyeingTBRChemicalValues = entity.DyeingTBRChemicals
                .SelectMany(x => x.DyeingTBRChemicalValues).ToList();
            var dbDyeingTBRChemicals = entity.DyeingTBRChemicals.Select(x =>
            {
                x.DyeingTBRChemicalValues = null;
                return x;
            }).ToList();

            var commandDyeingTBRChemicalValues = command.DyeingTBRChemicals
                .SelectMany(x => x.DyeingTBRChemicalValues).ToList();
            var commandDyeingTBRChemicals = command.DyeingTBRChemicals.ToList();
            entity.DyeingTBRChemicals = null;

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

            var dbDyeingTBRChemicalValueModifieds = dbDyeingTBRChemicalValues.Where(x => commandDyeingTBRChemicalValues.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(commandDyeingTBRChemicalValues.First(c => c.Id == x.Id), x));

            var newDyeingTBRChemicalValueAddeds = commandDyeingTBRChemicalValues.Where(x => x.Id == 0 && x.DyeingTBRChemicalId != 0)
                .Select(x => _mapper.Map<DyeingTBRChemicalValue>(x));

            var dbDyeingTBRChemicalValueDeletes =
                dbDyeingTBRChemicalValues.Where(x => dbDyeingTBRChemicalValueModifieds.All(y => y.Id != x.Id));

            #endregion DyeingTBRChemicalValue

            await _repository.UpdateDyeingTBRTaskAsync(entity, new BaseUpdateEntity<DyeingTBRChemical>
            {
                LstDataUpdate = dbDyeingTBRChemicalModifieds,
                LstDataAdd = newDyeingTBRChemicalAddeds,
                LstDataDelete = dbDyeingTBRChemicalDeletes
            }, new BaseUpdateEntity<DyeingTBRChemicalValue>
            {
                LstDataUpdate = dbDyeingTBRChemicalValueModifieds,
                LstDataAdd = newDyeingTBRChemicalValueAddeds,
                LstDataDelete = dbDyeingTBRChemicalValueDeletes
            });
            return new Response<int>(entity.Id);
        }
    }
}