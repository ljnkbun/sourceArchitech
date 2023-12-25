using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingFeatureBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingFeatures
{
    public class CreateSewingFeatureCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public decimal LabourCost { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal TotalSMV { get; set; }
        public virtual ICollection<SewingFeatureBOLModel> SewingFeatureBOLs { get; set; }
    }
    public class CreateSewingFeatureCommandHandler : IRequestHandler<CreateSewingFeatureCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingFeatureRepository _repository;
        public CreateSewingFeatureCommandHandler(IMapper mapper,
            ISewingFeatureRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingFeature>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
