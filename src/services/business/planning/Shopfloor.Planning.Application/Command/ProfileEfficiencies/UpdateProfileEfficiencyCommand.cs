using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Command.ProfileEfficiencyDetails;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.ProfileEfficiencies
{
    public class UpdateProfileEfficiencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int ProductGroupId { get; set; }
        public ICollection<UpdateProfileEfficiencyDetailCommand> ProfileEfficiencyDetails { get; set; }

        public bool IsActive { set; get; }
    }
    public class UpdateProfileEfficiencyCommandHandler : IRequestHandler<UpdateProfileEfficiencyCommand, Response<int>>
    {
        private readonly IProfileEfficiencyRepository _repository;
        private readonly IMapper _mapper;


        public UpdateProfileEfficiencyCommandHandler(IProfileEfficiencyRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateProfileEfficiencyCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetProfileEfficiencyByIdAsync(command.Id);

            if (entity == null) return new($"ProfileEfficiency Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.CategoryId = command.CategoryId;
            entity.ProductGroupId = command.ProductGroupId;
            entity.IsActive = command.IsActive;
            entity.ProfileEfficiencyDetails = _mapper.Map<ICollection<ProfileEfficiencyDetail>>(command.ProfileEfficiencyDetails);

            await _repository.UpdateProfileEfficiencyAsync(entity, entity.ProfileEfficiencyDetails);
            return new Response<int>(entity.Id);
        }
    }
}
