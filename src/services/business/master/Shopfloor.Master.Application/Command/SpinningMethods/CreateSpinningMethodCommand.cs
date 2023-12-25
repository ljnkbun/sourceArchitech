using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SpinningMethods
{
    public class CreateSpinningMethodCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateSpinningMethodCommandHandler : IRequestHandler<CreateSpinningMethodCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISpinningMethodRepository _repository;
        public CreateSpinningMethodCommandHandler(IMapper mapper,
            ISpinningMethodRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSpinningMethodCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SpinningMethod>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
