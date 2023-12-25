using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingOperationWFXs
{
    public class CreateVersionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class CreateVersionCommandHandler : IRequestHandler<CreateVersionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingOperationWFXRepository _repository;
        public CreateVersionCommandHandler(IMapper mapper,
            ISewingOperationWFXRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateVersionCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddVersionAsync(request.Id);
            return new Response<int>(request.Id);
        }
    }
}
