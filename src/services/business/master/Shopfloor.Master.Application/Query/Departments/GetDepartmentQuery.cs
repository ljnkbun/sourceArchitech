using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Departments
{
    public class GetDepartmentQuery : IRequest<Response<Department>>
    {
        public int Id { get; set; }
    }
    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, Response<Department>>
    {
        private readonly IDepartmentRepository _repository;
        public GetDepartmentQueryHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Department>> Handle(GetDepartmentQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Department Not Found (Id: {query.Id}).");
            return new Response<Department>(entity);
        }
    }
}
