using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Themes
{
    public class GetThemeQuery : IRequest<Response<Theme>>
    {
        public int Id { get; set; }
    }
    public class GetThemeQueryHandler : IRequestHandler<GetThemeQuery, Response<Theme>>
    {
        private readonly IThemeRepository _repository;
        public GetThemeQueryHandler(IThemeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Theme>> Handle(GetThemeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Theme Not Found (Id: {query.Id}).");
            return new Response<Theme>(entity);
        }
    }
}
