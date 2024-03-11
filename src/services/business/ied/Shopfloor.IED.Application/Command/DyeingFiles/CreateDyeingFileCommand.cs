using AutoMapper;
using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingFiles
{
    public class CreateDyeingFileCommand : IRequest<Response<int>>
    {
        public int DyeingIEDId { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
    }
    public class CreateDyeingFileCommandHandler : IRequestHandler<CreateDyeingFileCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingFileRepository _repository;
        public CreateDyeingFileCommandHandler(IMapper mapper,
            IDyeingFileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingFileCommand dyeingFile, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DyeingFile>(dyeingFile);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
