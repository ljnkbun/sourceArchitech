using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Command.ExportArticles;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Exports
{
    public class CreateExportCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public ExportStatus? Status { get; set; }
        public virtual ICollection<CreateExportArticleCommand> ExportArticles { get; set; }
    }

    public class CreateExportEntityCommandHandler : IRequestHandler<CreateExportCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IExportRepository _repository;

        public CreateExportEntityCommandHandler(IMapper mapper,
            IExportRepository repository
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateExportCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Export>(request);

            var rs = await _repository.AddAsync(entity);
            return new Response<int>(rs.Id);
        }
    }
}
