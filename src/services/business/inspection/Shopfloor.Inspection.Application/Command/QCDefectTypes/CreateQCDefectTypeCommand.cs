using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.QCDefectTypes
{
    public class CreateQCDefectTypeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateQCDefectTypeCommandHandler : IRequestHandler<CreateQCDefectTypeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IQCDefectTypeRepository _repository;
        public CreateQCDefectTypeCommandHandler(IMapper mapper,
            IQCDefectTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateQCDefectTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<QCDefectType>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
