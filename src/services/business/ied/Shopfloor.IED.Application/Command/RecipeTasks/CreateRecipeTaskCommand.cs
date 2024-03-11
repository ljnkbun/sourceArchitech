using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.RecipeChemicals;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RecipeTasks
{
    public class CreateRecipeTaskCommand : IRequest<Response<int>>
    {
        public int RecipeId { get; set; }

        public int DyeingProcessId { get; set; }

        public string DyeingProcessName { get; set; }

        public int DyeingOperationId { get; set; }

        public string DyeingOperationName { get; set; }

        public decimal Ratio { get; set; }

        public string DyeingProcessCode { get; set; }

        public string DyeingOperationCode { get; set; }

        public string MachineCode { get; set; }

        public string MachineName { get; set; }

        public decimal Time { get; set; }

        public decimal Temperature { get; set; }

        public ICollection<CreateRecipeChemicalCommand> RecipeChemical { get; set; }
    }

    public class CreateRecipeTaskCommandHandler : IRequestHandler<CreateRecipeTaskCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeTaskRepository _repository;

        public CreateRecipeTaskCommandHandler(IMapper mapper,
            IRecipeTaskRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRecipeTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.RecipeTask>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}