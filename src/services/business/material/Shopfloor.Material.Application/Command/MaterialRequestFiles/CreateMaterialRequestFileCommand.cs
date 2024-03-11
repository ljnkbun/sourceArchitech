using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.MaterialRequestFiles
{
    public class CreateMaterialRequestFileCommand : IRequest<Response<int>>
    {
        public int MaterialRequestId { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }
    }

    public class CreateMaterialRequestFileCommandHandler : IRequestHandler<CreateMaterialRequestFileCommand, Response<int>>
    {
        private readonly IMapper _mapper;

        private readonly IMaterialRequestFileRepository _repository;

        public CreateMaterialRequestFileCommandHandler(IMapper mapper, ILogger<CreateMaterialRequestFileCommand> logger,
            IMaterialRequestFileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaterialRequestFileCommand request,
            CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MaterialRequestFile>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}