using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingIEDs
{
    public class CreateSewingIEDCommand : IRequest<Response<int>>
    {
        public int RequestArticleOutputId { get; set; }
        public int? ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Buyer { get; set; }
        public string StyleRef { get; set; }
        public string ProductGroup { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal FactoryTime { get; set; }
        public decimal LabourCostOp { get; set; }
        public decimal LabourCostFactory { get; set; }
        public decimal FactoryOverheadAgainstLabourPercent { get; set; }
        public decimal LabourCostFactoryIncludingOverhead { get; set; }
        public string Comment { get; set; }
        public DateTime AnalysisDate { get; set; }
        public string AnalysisUser { get; set; }
        public Status Status { get; set; }
        public bool Deleted { get; set; }
    }
    public class CreateSewingIEDCommandHandler : IRequestHandler<CreateSewingIEDCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingIEDRepository _repository;
        public CreateSewingIEDCommandHandler(IMapper mapper,
            ISewingIEDRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingIEDCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingIED>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
