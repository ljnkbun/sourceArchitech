using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.ProblemCorrectiveActions
{
    public class CreateProblemCorrectiveActionCommand : IRequest<Response<int>>
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
    public class CreateProblemCorrectiveActionCommandHandler : IRequestHandler<CreateProblemCorrectiveActionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IProblemCorrectiveActionRepository _repository;
        public CreateProblemCorrectiveActionCommandHandler(IMapper mapper,
            IProblemCorrectiveActionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProblemCorrectiveActionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProblemCorrectiveAction>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
