using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingBundles
{
    public class CreateSewingBundleCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
    }

    public class CreateSewingBundleCommandHandler : IRequestHandler<CreateSewingBundleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingBundleRepository _repository;

        public CreateSewingBundleCommandHandler(IMapper mapper,
            ISewingBundleRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingBundleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.SewingBundle>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}