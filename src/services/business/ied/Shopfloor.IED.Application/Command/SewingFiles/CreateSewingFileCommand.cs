using AutoMapper;
using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingFiles
{
    public class CreateSewingFileCommand : IRequest<Response<int>>
    {
        public int SewingIEDId { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
    }
    public class CreateSewingFileCommandHandler : IRequestHandler<CreateSewingFileCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingFileRepository _repository;
        public CreateSewingFileCommandHandler(IMapper mapper,
            ISewingFileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingFileCommand sewingFile, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingFile>(sewingFile);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
