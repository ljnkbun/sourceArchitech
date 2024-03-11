using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.QCTypes
{
    public class CreateQCTypeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public QCScreenType QCScreenType { get; set; }

    }
    public class CreateQCTypeCommandHandler : IRequestHandler<CreateQCTypeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IQCTypeRepository _repository;
        public CreateQCTypeCommandHandler(IMapper mapper,
            IQCTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateQCTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<QCType>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
