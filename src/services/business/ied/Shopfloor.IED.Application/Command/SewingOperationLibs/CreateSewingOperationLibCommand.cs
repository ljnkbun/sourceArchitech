using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingMacroLibBOLs;
using Shopfloor.IED.Application.Models.SewingOperationLibBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingOperationLibs
{
    public class CreateSewingOperationLibCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public int SewingComponentId { get; set; }
        public int FolderTreeId { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal PersonalAllowance { get; set; }
        public decimal MachineDelay { get; set; }
        public decimal Contingency { get; set; }
        public decimal TotalSMV { get; set; }
        public decimal NoneMachineTime { get; set; }
        public decimal LabourCost { get; set; }
        public virtual ICollection<SewingOperationLibBOLModel> SewingOperationLibBOLs { get; set; }

    }
    public class CreateSewingOperationLibCommandHandler : IRequestHandler<CreateSewingOperationLibCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingOperationLibRepository _repository;
        public CreateSewingOperationLibCommandHandler(IMapper mapper,
            ISewingOperationLibRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingOperationLibCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingOperationLib>(request);
            await _repository.AddSewingOperationLibAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
