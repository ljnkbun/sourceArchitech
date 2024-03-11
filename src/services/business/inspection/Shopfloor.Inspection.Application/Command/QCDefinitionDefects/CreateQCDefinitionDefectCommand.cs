using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.QCDefinitionDefects
{
    public class CreateQCDefinitionDefectCommand : IRequest<Response<int>>
    {
        public int QCDefinitionId { get; set; }
		public int QCDefectId { get; set; }
    }
    public class CreateQCDefinitionDefectCommandHandler : IRequestHandler<CreateQCDefinitionDefectCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IQCDefinitionDefectRepository _repository;
        public CreateQCDefinitionDefectCommandHandler(IMapper mapper,
            IQCDefinitionDefectRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateQCDefinitionDefectCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<QCDefinitionDefect>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
