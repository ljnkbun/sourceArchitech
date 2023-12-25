using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Departments
{
    public class CreateDepartmentCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }

    }
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _repository;
        public CreateDepartmentCommandHandler(IMapper mapper,
            IDepartmentRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Department>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
