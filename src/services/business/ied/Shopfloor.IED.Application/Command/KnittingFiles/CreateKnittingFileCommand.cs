using AutoMapper;
using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingFiles
{
    public class CreateKnittingFileCommand : IRequest<Response<int>>
    {
        public int KnittingIEDId { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
    }
    public class CreateKnittingFileCommandHandler : IRequestHandler<CreateKnittingFileCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingFileRepository _repository;
        public CreateKnittingFileCommandHandler(IMapper mapper,
            IKnittingFileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateKnittingFileCommand knittingFile, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<KnittingFile>(knittingFile);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
