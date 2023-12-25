using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingSubOperationWFXResults;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingSubOperationWFXResults
{
    public class UpdateSewingSubOperationWFXResultCommand : IRequest<Response<int>>
    {
        public int SewingSubOperationWFXId { get; set; }
        public List<SewingSubOperationWFXResultModel> SewingSubOperationWFXResultModels { get; set; }

    }
    public class UpdateSewingSubOperationWFXResultCommandHandler : IRequestHandler<UpdateSewingSubOperationWFXResultCommand, Response<int>>
    {
        private readonly ISewingSubOperationWFXResultRepository _repository;
        private readonly IMapper _mapper;

        public UpdateSewingSubOperationWFXResultCommandHandler(ISewingSubOperationWFXResultRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateSewingSubOperationWFXResultCommand command, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<SewingSubOperationWFXResult>>(command.SewingSubOperationWFXResultModels);
            foreach (var entity in entities)
            {
                entity.SewingSubOperationWFXId = command.SewingSubOperationWFXId;
            }
            await _repository.UpdateSewingSubOperationWFXResultAsync(command.SewingSubOperationWFXId, entities);
            return new Response<int>(command.SewingSubOperationWFXId);
        }
    }
}
