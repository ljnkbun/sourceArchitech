using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingOperationLibResults;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingOperationLibResults
{
    public class UpdateSewingOperationLibResultCommand : IRequest<Response<int>>
    {
        public int SewingOperationLibId { get; set; }
        public List<SewingOperationLibResultModel> SewingOperationLibResultModels { get; set; }

    }
    public class UpdateSewingOperationLibResultCommandHandler : IRequestHandler<UpdateSewingOperationLibResultCommand, Response<int>>
    {
        private readonly ISewingOperationLibResultRepository _repository;
        private readonly IMapper _mapper;

        public UpdateSewingOperationLibResultCommandHandler(ISewingOperationLibResultRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateSewingOperationLibResultCommand command, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<SewingOperationLibResult>>(command.SewingOperationLibResultModels);
            foreach (var entity in entities)
            {
                entity.SewingOperationLibId = command.SewingOperationLibId;
            }
            await _repository.UpdateSewingOperationLibResultAsync(command.SewingOperationLibId, entities);
            return new Response<int>(command.SewingOperationLibId);
        }
    }
}
