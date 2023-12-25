using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Micronaires
{
    public class CreateMicronaireCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateMicronaireCommandHandler : IRequestHandler<CreateMicronaireCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IMicronaireRepository _repository;
        public CreateMicronaireCommandHandler(IMapper mapper,
            IMicronaireRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMicronaireCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Micronaire>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
