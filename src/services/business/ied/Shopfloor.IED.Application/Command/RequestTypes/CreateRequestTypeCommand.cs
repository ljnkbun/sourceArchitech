using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestTypes
{
    public class CreateRequestTypeCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    public class CreateRequestTypeCommandHandler : IRequestHandler<CreateRequestTypeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestTypeRepository _repository;
        public CreateRequestTypeCommandHandler(IMapper mapper,
            IRequestTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRequestTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<RequestType>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
