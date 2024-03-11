using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.SewingMachineEfficiencyProfiles;
using Shopfloor.IED.Application.Command.SewingSubcategoryEfficiencies;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingEfficiencyProfiles
{
    public class CreateSewingEfficiencyProfileCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public decimal PersonalAllowance { get; set; }
        public decimal MachineDelay { get; set; }
        public decimal Contingency { get; set; }
        public bool? IsDefault { get; set; }
        public ICollection<CreateSewingMachineEfficiencyProfileCommand> SewingMachineEfficiencyProfiles { get; set; }
        public ICollection<CreateSewingSubcategoryEfficiencyCommand> SewingSubcategoryEfficiencies { get; set; }
    }

    public class CreateSewingEfficiencyProfileCommandHandler : IRequestHandler<CreateSewingEfficiencyProfileCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingEfficiencyProfileRepository _repository;

        public CreateSewingEfficiencyProfileCommandHandler(IMapper mapper,
            ISewingEfficiencyProfileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingEfficiencyProfileCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.SewingEfficiencyProfile>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}