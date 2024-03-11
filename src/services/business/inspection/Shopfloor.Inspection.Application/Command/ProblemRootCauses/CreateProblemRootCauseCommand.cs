using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.ProblemRootCauses
{
    public class CreateProblemRootCauseCommand : IRequest<Response<int>>
    {
        public string NameVN { get; set; }
		public string NameEN { get; set; }
		public int? DivisonId { get; set; }
		public string DivisonName { get; set; }
		public int? ProcessId { get; set; }
		public string ProcessName { get; set; }
		public int? CategoryId { get; set; }
		public string CategoryName { get; set; }
		public int? SubCategoryId { get; set; }
		public string SubCategoryName { get; set; }
		public InspectionType? InspectionType { get; set; }
    }
    public class CreateProblemRootCauseCommandHandler : IRequestHandler<CreateProblemRootCauseCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IProblemRootCauseRepository _repository;
        public CreateProblemRootCauseCommandHandler(IMapper mapper,
            IProblemRootCauseRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProblemRootCauseCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProblemRootCause>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
