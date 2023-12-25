using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.BarcodeLocations
{
    public class CreateBarcodeLocationCommand : IRequest<Response<int>>
    {
        public int? LocationId { get; set; }
        public int? ArticleBarcodeId { get; set; }
    }
    public class CreateBarcodeLocationCommandHandler : IRequestHandler<CreateBarcodeLocationCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IBarcodeLocationRepository _repository;
        public CreateBarcodeLocationCommandHandler(IMapper mapper,
            IBarcodeLocationRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateBarcodeLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BarcodeLocation>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
