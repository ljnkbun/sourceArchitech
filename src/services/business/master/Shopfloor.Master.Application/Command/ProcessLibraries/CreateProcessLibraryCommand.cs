using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ProcessLibraries
{
    public class CreateProcessLibraryCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateProcessLibraryCommandHandler : IRequestHandler<CreateProcessLibraryCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IProcessLibraryRepository _repository;
        public CreateProcessLibraryCommandHandler(IMapper mapper,
            IProcessLibraryRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProcessLibraryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProcessLibrary>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
