using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingFeatureBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingFeatures
{
    public class UpdateSewingFeatureCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LineCode { get; set; }
        public decimal LabourCost { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal TotalSMV { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { set; get; }
        public virtual ICollection<SewingFeatureBOLModel> SewingFeatureBOLs { get; set; }
    }
    public class UpdateSewingFeatureCommandHandler : IRequestHandler<UpdateSewingFeatureCommand, Response<int>>
    {
        private readonly ISewingFeatureRepository _repository;
        private readonly IMapper _mapper;
        public UpdateSewingFeatureCommandHandler(ISewingFeatureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateSewingFeatureCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"SewingFeature Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.Description = command.Description;
            entity.LineCode = command.LineCode;
            entity.LabourCost = command.LabourCost;
            entity.AllowedTime = command.AllowedTime;
            entity.TotalSMV = command.TotalSMV;
            entity.Deleted = command.Deleted;
            entity.IsActive = command.IsActive;
            entity.SewingFeatureBOLs = null;

            var newSewingFeatureBOLs = _mapper.Map<List<SewingFeatureBOL>>(command.SewingFeatureBOLs);
            foreach (var item in newSewingFeatureBOLs ?? Enumerable.Empty<SewingFeatureBOL>())
            {
                item.SewingFeatureId = entity.Id;
            }

            await _repository.UpdateSewingFeatureAsync(entity, newSewingFeatureBOLs);
            return new Response<int>(entity.Id);
        }
    }
}
