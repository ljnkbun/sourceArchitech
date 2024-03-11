using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.Attachments;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturing4PointSyss;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.Inpection4PointSyss
{
    public class CreateInpection4PointSysCommand : IRequest<Response<int>>
    {
        public int? QCRequestArticleId { get; set; }
        public string StockMovementNo { get; set; }
        public decimal CaptureMeter { get; set; }
        public decimal ActualWeight { get; set; }
        public int TotalDefect { get; set; }
        public int TotalContDefect { get; set; }
        public int TotalPoint { get; set; }
        public int PointSquareMeter { get; set; }
        public int? WarpDensity { get; set; }
        public int? WeftDensity { get; set; }
        public int PersonInChargeId { get; set; }
        public string Remark { get; set; }
        public int? AttachmentId { get; set; }
        public bool SystemResult { get; set; }
        public bool UserResult { get; set; }
        public string Grade { get; set; }
        public decimal? WeightGM2 { get; set; }
        public bool IsCreatedFromProduction { get; set; }
        public DateTime InspectionDate { get; set; }
        public ICollection<CreateAttachmentCommand> Attachments { get; set; }
        public ICollection<CreateInspectionDefectCapturing4PointSysCommand> InspectionDefectCapturing4PointSyss { get; set; }
    }
    public class CreateInpection4PointSysCommandHandler : IRequestHandler<CreateInpection4PointSysCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IInpection4PointSysRepository _repository;
        public CreateInpection4PointSysCommandHandler(IMapper mapper,
            IInpection4PointSysRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateInpection4PointSysCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Inpection4PointSys>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
