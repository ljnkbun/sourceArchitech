using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SubCategories
{
    public class CreateSubCategoryCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int SubCategoryGroupId { get; set; }
        public string ExciseTarrifNo { get; set; }
        public bool PackagingUnit { get; set; }
        public bool ByPassPriceList { get; set; }
        public bool DefaultInactiveIndent { get; set; }
        public int ProductGroupId { get; set; }
    }
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISubCategoryRepository _repository;
        public CreateSubCategoryCommandHandler(IMapper mapper,
            ISubCategoryRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SubCategory>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
