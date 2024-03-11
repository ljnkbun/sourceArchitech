using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingFeatureLibBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingFeatureLibs
{
    public class CreateSewingFeatureLibCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public int SewingComponentId { get; set; }
        public decimal LabourCost { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal TotalSMV { get; set; }
        public int FolderTreeId { get; set; }
        public virtual ICollection<SewingFeatureLibBOLModel> SewingFeatureLibBOLs { get; set; }
    }
    public class CreateSewingFeatureLibCommandHandler : IRequestHandler<CreateSewingFeatureLibCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingFeatureLibRepository _repository;
        public CreateSewingFeatureLibCommandHandler(IMapper mapper,
            ISewingFeatureLibRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingFeatureLibCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingFeatureLib>(request);
            await _repository.AddSewingFeatureLibAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
