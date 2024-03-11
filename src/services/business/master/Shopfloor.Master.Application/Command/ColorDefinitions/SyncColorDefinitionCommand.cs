using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.ColorDefinitions;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ColorDefinitions
{
    public class SyncColorDefinitionCommand : IRequest<Response<bool>>
    {
        public List<ColorDefinitionWFXModel> Data { get; set; }
    }
    public class SyncColorDefinitionCommandHandler : IRequestHandler<SyncColorDefinitionCommand, Response<bool>>
    {
        private readonly IColorDefinitionRepository _repository;
        public SyncColorDefinitionCommandHandler(IColorDefinitionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(SyncColorDefinitionCommand command, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            var newEntities = GetNewEntities(entities, command.Data);
            var updateEntities = GetUpdateEntities(entities, command.Data);

            if (newEntities.Count > 0) { await _repository.AddRangeAsync(newEntities); }
            if (updateEntities.Count > 0) { await _repository.UpdateRangeAsync(updateEntities); }

            return new Response<bool>(true);
        }

        private List<ColorDefinition> GetNewEntities(IReadOnlyList<ColorDefinition> entities, List<ColorDefinitionWFXModel> input)
        {
            var entites = new List<ColorDefinition>();
            // handle logic, mapping
            return entites;
        }

        private List<ColorDefinition> GetUpdateEntities(IReadOnlyList<ColorDefinition> entities, List<ColorDefinitionWFXModel> input)
        {
            var entites = new List<ColorDefinition>();
            // handle logic, mapping
            return entites;
        }
    }
}
