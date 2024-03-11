using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.ProfileEfficiencyDetails
{
    public class CreateProfileEfficiencyDetailCommand : IRequest<Response<int>>
    {
        public int ProfileEfficiencyId { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public decimal EfficiencyValue { get; set; }

    }
    public class CreateProfileEfficiencyDetailCommandHandler : IRequestHandler<CreateProfileEfficiencyDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IProfileEfficiencyDetailRepository _repository;
        public CreateProfileEfficiencyDetailCommandHandler(IMapper mapper,
            IProfileEfficiencyDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProfileEfficiencyDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProfileEfficiencyDetail>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
