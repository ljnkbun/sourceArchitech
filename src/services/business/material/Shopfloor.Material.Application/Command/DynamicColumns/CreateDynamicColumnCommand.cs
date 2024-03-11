using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.DynamicColumnContents;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.DynamicColumns
{
    public class CreateDynamicColumnCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public FieldType FieldType { get; set; }

        public bool IsContent { get; set; }

        public bool IsRequired { get; set; }

        public bool IsActive { get; set; }

        public string CategoryCode { get; set; }

        public int DisplayIndex { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? CreatedUserId { get; set; }

        public Guid? ModifiedUserId { get; set; }

        public ICollection<DynamicColumnContentModel> DynamicColumnContents { get; set; }
    }

    public class CreateDynamicColumnCommandHandler : IRequestHandler<CreateDynamicColumnCommand, Response<int>>
    {
        private readonly IMapper _mapper;

        private readonly IDynamicColumnRepository _repository;

        public CreateDynamicColumnCommandHandler(IMapper mapper,
            IDynamicColumnRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDynamicColumnCommand request,
            CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DynamicColumn>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}