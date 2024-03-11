using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.SewingMachineEfficiencyProfiles;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingEfficiencyProfiles
{
    public class UpdateSewingEfficiencyProfileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PersonalAllowance { get; set; }
        public decimal MachineDelay { get; set; }
        public decimal Contingency { get; set; }
        public bool? IsDefault { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UpdateSewingMachineEfficiencyProfileCommand> SewingMachineEfficiencyProfiles { get; set; }
    }

    public class UpdateSewingEfficiencyProfileCommandHandler : IRequestHandler<UpdateSewingEfficiencyProfileCommand, Response<int>>
    {
        private readonly ISewingEfficiencyProfileRepository _repository;
        private readonly IMapper _mapper;

        public UpdateSewingEfficiencyProfileCommandHandler(ISewingEfficiencyProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateSewingEfficiencyProfileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(command.Id);

            if (entity == null) return new($"SewingEfficiencyProfile Not Found.");

            entity.Name = command.Name;
            entity.PersonalAllowance = command.PersonalAllowance;
            entity.MachineDelay = command.MachineDelay;
            entity.Contingency = command.Contingency;
            entity.IsDefault = command.IsDefault;
            entity.IsActive = command.IsActive;
            var dbSewingMachineEfficiencyProfiles = entity.SewingMachineEfficiencyProfiles;
            entity.SewingMachineEfficiencyProfiles = null;

            #region SewingMachineEfficiencyProfile

            var dbSewingMachineEfficiencyProfileModifieds = dbSewingMachineEfficiencyProfiles.Where(x => command.SewingMachineEfficiencyProfiles.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(command.SewingMachineEfficiencyProfiles.First(c => c.Id == x.Id), x));

            var newSewingMachineEfficiencyProfileAddeds = command.SewingMachineEfficiencyProfiles.Where(x => x.Id == 0)
                .Select(x => _mapper.Map<SewingMachineEfficiencyProfile>(x));

            var dbSewingMachineEfficiencyProfileDeletes =
                dbSewingMachineEfficiencyProfiles.Where(x => dbSewingMachineEfficiencyProfileModifieds.All(y => y.Id != x.Id));

            #endregion SewingMachineEfficiencyProfile

            await _repository.UpdateSewingMachineEfficiencyProfileAsync(entity, new BaseUpdateEntity<SewingMachineEfficiencyProfile>
            {
                LstDataAdd = newSewingMachineEfficiencyProfileAddeds,
                LstDataDelete = dbSewingMachineEfficiencyProfileDeletes,
                LstDataUpdate = dbSewingMachineEfficiencyProfileModifieds
            });
            return new Response<int>(entity.Id);
        }
    }
}