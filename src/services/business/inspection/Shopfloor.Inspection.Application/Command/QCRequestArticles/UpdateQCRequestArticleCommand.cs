using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.QCRequestArticles
{
    public class UpdateQCRequestArticleCommand : IRequest<Response<int>>
    {
        public int QCRequestId { get; set; }
		public string ArticleCode { get; set; }
		public string ArticleName { get; set; }
		public string Shade { get; set; }
		public string Lot { get; set; }
		public string StyleNo { get; set; }
		public string StyleName { get; set; }
		public string Season { get; set; }
		public string Buyer { get; set; }
		public string FPONo { get; set; }
		public string Location { get; set; }
		public string UOM { get; set; }
		public string OCNo { get; set; }
		public string GRNNo { get; set; }
		public string PONo { get; set; }
		public DateTime? GRNDate { get; set; }
		public decimal RequestedQty { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public decimal QCReleasedQty { get; set; }
        public decimal GRNQty { get; set; }
        public string JobOrderNo { get; set; }
        public string BatchNo { get; set; }
        public string Line { get; set; }
        public string Machine { get; set; }
        public decimal PlannedQty { get; set; }
        public decimal MadeQty { get; set; }
        public decimal BalanceQty { get; set; }
        public decimal WeightKg { get; set; }
        public decimal WidghtKg { get; set; }
        public decimal Length { get; set; }
        public decimal RollQty { get; set; }
        public int Id { get; set; }
       
        public bool IsActive { set; get; }
    }
    public class UpdateQCRequestArticleCommandHandler : IRequestHandler<UpdateQCRequestArticleCommand, Response<int>>
    {
        private readonly IQCRequestArticleRepository _repository;
        public UpdateQCRequestArticleCommandHandler(IQCRequestArticleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateQCRequestArticleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"QCRequestArticle Not Found.");
            entity.IsActive = command.IsActive;
            entity.QCRequestId = command.QCRequestId;
			entity.ArticleCode = command.ArticleCode;
			entity.ArticleName = command.ArticleName;
			entity.Shade = command.Shade;
			entity.Lot = command.Lot;
			entity.StyleNo = command.StyleNo;
			entity.StyleName = command.StyleName;
			entity.Season = command.Season;
			entity.Buyer = command.Buyer;
			entity.FPONo = command.FPONo;
			entity.Location = command.Location;
			entity.UOM = command.UOM;
			entity.OCNo = command.OCNo;
			entity.GRNNo = command.GRNNo;
			entity.PONo = command.PONo;
			entity.GRNDate = command.GRNDate;
			entity.RequestedQty = command.RequestedQty;
			entity.ColorCode = command.ColorCode;
			entity.ColorName = command.ColorName;
			entity.SizeCode = command.SizeCode;
			entity.SizeName = command.SizeName;
			entity.QCReleasedQty = command.QCReleasedQty;
			entity.GRNQty = command.GRNQty;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
