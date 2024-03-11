using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.QCDefects
{
    public class UpdateQCDefectCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int QCDefecTypeId { get; set; }
		public int? ParrentId { get; set; }
		public string NameEN { get; set; }
		public int? DivisonId { get; set; }
		public string DivisonName { get; set; }
		public int? ProcessId { get; set; }
		public string ProcessName { get; set; }
		public int? CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string SubCategoryId { get; set; }
		public string SubCategoryName { get; set; }
		public int Level { get; set; }
		public InspectionType InspectionType { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateQCDefectCommandHandler : IRequestHandler<UpdateQCDefectCommand, Response<int>>
    {
        private readonly IQCDefectRepository _repository;
        public UpdateQCDefectCommandHandler(IQCDefectRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateQCDefectCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null)  return new ($"QCDefect Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;
            entity.QCDefecTypeId = command.QCDefecTypeId;
			entity.ParrentId = command.ParrentId;
			entity.NameEN = command.NameEN;
			entity.DivisonId = command.DivisonId;
			entity.DivisonName = command.DivisonName;
			entity.ProcessId = command.ProcessId;
			entity.ProcessName = command.ProcessName;
			entity.CategoryId = command.CategoryId;
			entity.CategoryName = command.CategoryName;
			entity.SubCategoryId = command.SubCategoryId;
			entity.SubCategoryName = command.SubCategoryName;
			entity.Level = command.Level;
			entity.InspectionType = command.InspectionType;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
