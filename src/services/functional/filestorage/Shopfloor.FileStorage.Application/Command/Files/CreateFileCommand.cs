using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.FileStorage.Domain.Interfaces;

namespace Shopfloor.FileStorage.Application.Command.Files
{
    public class CreateFileCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public string Folder { get; set; }
    }
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFileRepository _repository;
        public CreateFileCommandHandler(IMapper mapper,
            IFileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.File>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
