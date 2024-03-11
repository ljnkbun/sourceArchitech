using AutoMapper;
using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRequestFiles
{
    public class CreateDyeingTBRequestFileCommand : IRequest<Response<int>>
    {
        public int DyeingTBRequestId { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }
    }

    public class CreateDyeingTBRequestFileCommandHandler : IRequestHandler<CreateDyeingTBRequestFileCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRequestFileRepository _repository;

        public CreateDyeingTBRequestFileCommandHandler(IMapper mapper,
            IDyeingTBRequestFileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingTBRequestFileCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DyeingTBRequestFile>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}