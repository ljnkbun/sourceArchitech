using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportDetails
{
    public class UpdateImportDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public ItemStatus? Status { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public decimal? Quantity { get; set; }
        public string UOM { get; set; }
        public string Unit { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public string Location { get; set; }
        public int LocationId { get; set; }
        public string Note { get; set; }
        public int ImportArticleId { get; set; }
        public EntityState EntityState { get; set; }
        public ImportType? Type { get; set; }

    }

    public class UpdateImportDetailCommandHandler : IRequestHandler<UpdateImportDetailCommand, Response<int>>
    {
        private readonly IImportDetailRepository _repository;
        private readonly IMapper _mapper;
        public UpdateImportDetailCommandHandler(IMapper mapper, IImportDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateImportDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id) ?? throw new ApiException($"ImportDetail Not Found.");
            _mapper.Map<UpdateImportDetailCommand, ImportDetail>(command, entity);
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
