using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.OperationLibraries
{
    public class CreateOperationLibraryCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int ProcessLibraryId { get; set; }
    }
    public class CreateOperationLibraryCommandHandler : IRequestHandler<CreateOperationLibraryCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IOperationLibraryRepository _repository;
        public CreateOperationLibraryCommandHandler(IMapper mapper,
            IOperationLibraryRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateOperationLibraryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<OperationLibrary>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
