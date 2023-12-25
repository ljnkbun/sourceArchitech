using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Countries
{
    public class CreateCountryCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _repository;
        public CreateCountryCommandHandler(IMapper mapper,
            ICountryRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Country>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
