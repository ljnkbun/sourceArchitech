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
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FolderTreeId { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalTMU { get; set; }
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
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
