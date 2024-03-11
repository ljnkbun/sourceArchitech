using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Command.ProfileEfficiencyDetails;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.ProfileEfficiencies
{
    public class CreateProfileEfficiencyCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductGroupCode { get; set; }
        public string ProductGroupName { get; set; }
        public ICollection<CreateProfileEfficiencyDetailCommand> ProfileEfficiencyDetails { get; set; }

    }
    public class CreateProfileEfficiencyCommandHandler : IRequestHandler<CreateProfileEfficiencyCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IProfileEfficiencyRepository _repository;
        public CreateProfileEfficiencyCommandHandler(IMapper mapper,
            IProfileEfficiencyRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProfileEfficiencyCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProfileEfficiency>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
