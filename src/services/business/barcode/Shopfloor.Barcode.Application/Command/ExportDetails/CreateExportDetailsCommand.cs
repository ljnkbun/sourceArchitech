using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportDetails
{
    public class CreateExportDetailsCommand : IRequest<Response<bool>>
    {
        public ICollection<CreateExportDetailCommand> ExportDetails { get; set; }
    }

    public class CreateExportDetailsEntityCommandHandler : IRequestHandler<CreateExportDetailsCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IExportDetailRepository _repository;

        public CreateExportDetailsEntityCommandHandler(IMapper mapper,
            IExportDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateExportDetailsCommand request, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<ExportDetail>>(request.ExportDetails);

            var rs = await _repository.AddRangeAsync(entities);
            return new Response<bool>(rs);
        }
    }
}
