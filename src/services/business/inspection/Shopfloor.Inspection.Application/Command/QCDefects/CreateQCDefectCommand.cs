using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.QCDefects
{
    public class CreateQCDefectCommand : IRequest<Response<int>>
    {
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
    }
    public class CreateQCDefectCommandHandler : IRequestHandler<CreateQCDefectCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IQCDefectRepository _repository;
        public CreateQCDefectCommandHandler(IMapper mapper,
            IQCDefectRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateQCDefectCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<QCDefect>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
