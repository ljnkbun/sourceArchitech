using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingSubOperationWFXResults;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingSubOperationWFXResults
{
    public class CreateSewingSubOperationWFXResultCommand : IRequest<Response<bool>>
    {
        public int SewingSubOperationWFXId { get; set; }
        public List<SewingSubOperationWFXResultModel> SewingSubOperationWFXResultModels { get; set; }

    }
    public class CreateSewingSubOperationWFXResultCommandHandler : IRequestHandler<CreateSewingSubOperationWFXResultCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingSubOperationWFXResultRepository _repository;
        public CreateSewingSubOperationWFXResultCommandHandler(IMapper mapper,
            ISewingSubOperationWFXResultRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateSewingSubOperationWFXResultCommand request, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<SewingSubOperationWFXResult>>(request.SewingSubOperationWFXResultModels);
            foreach (var entity in entities ?? Enumerable.Empty<SewingSubOperationWFXResult>())
            {
                entity.SewingSubOperationWFXId = request.SewingSubOperationWFXId;
            }
            bool result = await _repository.AddRangeAsync(entities);
            return new Response<bool>(result);
        }
    }
}
