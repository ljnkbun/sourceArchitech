using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingSubcategoryEfficiencies
{
    public class CreateSewingSubcategoryEfficiencyCommand : IRequest<Response<int>>
    {
        public int SewingEfficiencyProfileId { get; set; }

        public string SubCategory { get; set; }
    }

    public class CreateSewingSubcategoryEfficiencyCommandHandler : IRequestHandler<CreateSewingSubcategoryEfficiencyCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingSubcategoryEfficiencyRepository _repository;

        public CreateSewingSubcategoryEfficiencyCommandHandler(IMapper mapper,
            ISewingSubcategoryEfficiencyRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingSubcategoryEfficiencyCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.SewingSubcategoryEfficiency>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}