using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingOperationLibResults;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingOperationLibResults
{
    public class CreateSewingOperationLibResultCommand : IRequest<Response<bool>>
    {
        public int SewingOperationLibId { get; set; }
        public List<SewingOperationLibResult> SewingOperationLibResults { get; set; }

    }
    public class CreateSewingOperationLibResultCommandHandler : IRequestHandler<CreateSewingOperationLibResultCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingOperationLibResultRepository _repository;
        public CreateSewingOperationLibResultCommandHandler(IMapper mapper,
            ISewingOperationLibResultRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateSewingOperationLibResultCommand request, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<SewingOperationLibResult>>(request.SewingOperationLibResults);
            foreach (var entity in entities ?? Enumerable.Empty<SewingOperationLibResult>())
            {
                entity.SewingOperationLibId = request.SewingOperationLibId;
            }
            bool result = await _repository.AddRangeAsync(entities);
            return new Response<bool>(result);
        }
    }
}
