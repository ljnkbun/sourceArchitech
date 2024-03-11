using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.ProblemRootCauses
{
    public class UpdateProblemRootCauseCommand : IRequest<Response<int>>
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
        public int Id { get; set; }
       
        public bool IsActive { set; get; }
    }
    public class UpdateProblemRootCauseCommandHandler : IRequestHandler<UpdateProblemRootCauseCommand, Response<int>>
    {
        private readonly IProblemRootCauseRepository _repository;
        public UpdateProblemRootCauseCommandHandler(IProblemRootCauseRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateProblemRootCauseCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new ($"ProblemRootCause Not Found.");
            entity.IsActive = command.IsActive;
            entity.NameVN = command.NameVN;
			entity.NameEN = command.NameEN;
			entity.DivisonId = command.DivisonId;
			entity.DivisonName = command.DivisonName;
			entity.ProcessId = command.ProcessId;
			entity.ProcessName = command.ProcessName;
			entity.CategoryId = command.CategoryId;
			entity.CategoryName = command.CategoryName;
			entity.SubCategoryId = command.SubCategoryId;
			entity.SubCategoryName = command.SubCategoryName;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
