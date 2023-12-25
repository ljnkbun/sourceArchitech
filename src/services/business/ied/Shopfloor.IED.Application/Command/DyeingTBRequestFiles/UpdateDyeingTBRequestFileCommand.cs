﻿using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRequestFiles
{
    public class UpdateDyeingTBRequestFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int DyeingTBRequestId { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateDyeingTBRequestFileCommandHandler : IRequestHandler<UpdateDyeingTBRequestFileCommand, Response<int>>
    {
        private readonly IDyeingTBRequestFileRepository _repository;

        public UpdateDyeingTBRequestFileCommandHandler(IDyeingTBRequestFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBRequestFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"DyeingTBRequestFile Not Found.");

            entity.FileId = command.FileId;
            entity.Description = command.Description;
            entity.FileName = command.FileName;
            entity.DyeingTBRequestId = command.DyeingTBRequestId;
            entity.FileType = command.FileType;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}