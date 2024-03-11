using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RecipeChemicals
{
    public class CreateRecipeChemicalCommand : IRequest<Response<int>>
    {
        public int RecipeTaskId { get; set; }

        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string ChemicalSubcategory { get; set; }

        public string Unit { get; set; }

        public decimal Value { get; set; }
    }

    public class CreateRecipeChemicalCommandHandler : IRequestHandler<CreateRecipeChemicalCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeChemicalRepository _repository;

        public CreateRecipeChemicalCommandHandler(IMapper mapper,
            IRecipeChemicalRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRecipeChemicalCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.RecipeChemical>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}