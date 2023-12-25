using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.MachineTypes
{
    public class CreateMachineTypeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateMachineTypeCommandHandler : IRequestHandler<CreateMachineTypeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IMachineTypeRepository _repository;
        public CreateMachineTypeCommandHandler(IMapper mapper,
            IMachineTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMachineTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MachineType>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
