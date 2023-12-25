using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.FiberTypes
{
    public class CreateFiberTypeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateFiberTypeCommandHandler : IRequestHandler<CreateFiberTypeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFiberTypeRepository _repository;
        public CreateFiberTypeCommandHandler(IMapper mapper,
            IFiberTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFiberTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<FiberType>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
