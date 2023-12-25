using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SubOperationLibraries
{
    public class CreateSubOperationLibraryCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int OperationLibraryId { get; set; }
    }
    public class CreateSubOperationLibraryCommandHandler : IRequestHandler<CreateSubOperationLibraryCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISubOperationLibraryRepository _repository;
        public CreateSubOperationLibraryCommandHandler(IMapper mapper,
            ISubOperationLibraryRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSubOperationLibraryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SubOperationLibrary>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
