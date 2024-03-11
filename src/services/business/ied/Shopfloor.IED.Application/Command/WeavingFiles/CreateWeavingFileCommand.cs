using AutoMapper;
using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingFiles
{
    public class CreateWeavingFileCommand : IRequest<Response<int>>
    {
        public int WeavingIEDId { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
    }
    public class CreateWeavingFileCommandHandler : IRequestHandler<CreateWeavingFileCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingFileRepository _repository;
        public CreateWeavingFileCommandHandler(IMapper mapper,
            IWeavingFileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingFileCommand weavingFile, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingFile>(weavingFile);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
