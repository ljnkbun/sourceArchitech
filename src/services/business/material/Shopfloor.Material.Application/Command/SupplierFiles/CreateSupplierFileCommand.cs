using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.SupplierFiles
{
    public class CreateSupplierFileCommand : IRequest<Response<int>>
    {
        public int SupplierId { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }
    }

    public class CreateSupplierFileCommandHandler : IRequestHandler<CreateSupplierFileCommand, Response<int>>
    {
        private readonly IMapper _mapper;

        private readonly ISupplierFileRepository _repository;

        public CreateSupplierFileCommandHandler(IMapper mapper, ILogger<CreateSupplierFileCommand> logger,
            ISupplierFileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSupplierFileCommand request,
            CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SupplierFile>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}