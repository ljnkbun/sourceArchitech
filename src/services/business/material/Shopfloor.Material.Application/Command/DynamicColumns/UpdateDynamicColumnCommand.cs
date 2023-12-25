﻿using AutoMapper;

using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.DynamicColumnContents;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.DynamicColumns
{
    public class UpdateDynamicColumnCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public FieldType FieldType { get; set; }

        public bool IsContent { get; set; }

        public bool IsRequired { get; set; }

        public int DisplayIndex { get; set; }

        public string CategoryCode { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? CreatedUserId { get; set; }

        public Guid? ModifiedUserId { get; set; }

        public List<DynamicColumnContentModel> DynamicColumnContents { get; set; }
    }

    public class UpdateDynamicColumnCommandHandler : IRequestHandler<UpdateDynamicColumnCommand, Response<int>>
    {
        private readonly IDynamicColumnRepository _repositoryDynamicColumn;

        private readonly IMapper _mapper;

        public UpdateDynamicColumnCommandHandler(IDynamicColumnRepository repositoryMaterial,
            IMapper mapper)
        {
            _repositoryDynamicColumn = repositoryMaterial;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateDynamicColumnCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repositoryDynamicColumn.GetWithIncludeByIdAsync(command.Id);
            if (entity == null)
                throw new ApiException($"DynamicColumn Not Found.");
            var dataDynamicColumn = _mapper.Map<DynamicColumn>(command);
            entity.Name = dataDynamicColumn.Name;
            entity.Code = dataDynamicColumn.Code;
            entity.FieldType = dataDynamicColumn.FieldType;
            entity.IsRequired = dataDynamicColumn.IsRequired;
            entity.IsContent = dataDynamicColumn.IsContent;
            entity.CategoryCode = dataDynamicColumn.CategoryCode;

            #region DynamicColumnContents

            // lay ra Entities can add them
            var addEntitiesDynamicColumnContents =
                dataDynamicColumn.DynamicColumnContents.Where(x => x.Id == 0).ToList();

            // lấy ra Entities cần update
            var updateEntitiesDynamicColumnContents =
                dataDynamicColumn.DynamicColumnContents.Where(x => x.Id != 0).ToList();

            // lấy ra Entities cần remove
            var deleteEntitiesDynamicColumnContents =
                entity.DynamicColumnContents.Where(x => !updateEntitiesDynamicColumnContents.Any() || updateEntitiesDynamicColumnContents.Any(y => y.Id != x.Id)).ToList();

            #endregion DynamicColumnContents

            entity.DynamicColumnContents = updateEntitiesDynamicColumnContents;

            await _repositoryDynamicColumn.UpdateDynamicColumnAsync(entity, new BaseListCreateDeleteEntity<DynamicColumnContent>
            {
                LstDataAdd = addEntitiesDynamicColumnContents,
                LstDataDelete = deleteEntitiesDynamicColumnContents
            });

            return new Response<int>(command.Id);
        }
    }
}