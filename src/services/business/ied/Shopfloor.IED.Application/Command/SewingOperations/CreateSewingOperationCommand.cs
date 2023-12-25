using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingOperationBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingOperations
{
    public class CreateSewingOperationCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public decimal NoneMachineTime { get; set; }
        public decimal LabourCost { get; set; }
        public virtual ICollection<SewingOperationBOLModel> SewingOperationBOLs { get; set; }

    }
    public class CreateSewingOperationCommandHandler : IRequestHandler<CreateSewingOperationCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingOperationRepository _repository;
        public CreateSewingOperationCommandHandler(IMapper mapper,
            ISewingOperationRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingOperationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingOperation>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
