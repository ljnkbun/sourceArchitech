﻿using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingFeatureLibBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingFeatureLibs
{
    public class UpdateSewingFeatureLibCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public int SewingComponentId { get; set; }
        public decimal LabourCost { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal TotalSMV { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { set; get; }
        public virtual ICollection<SewingFeatureLibBOLModel> SewingFeatureLibBOLs { get; set; }
    }
    public class UpdateSewingFeatureLibCommandHandler : IRequestHandler<UpdateSewingFeatureLibCommand, Response<int>>
    {
        private readonly ISewingFeatureLibRepository _repository;
        private readonly ISewingFeatureLibBOLRepository _bolRepository;
        public UpdateSewingFeatureLibCommandHandler(ISewingFeatureLibRepository repository, ISewingFeatureLibBOLRepository bolRepository)
        {
            _repository = repository;
            _bolRepository = bolRepository;
        }
        public async Task<Response<int>> Handle(UpdateSewingFeatureLibCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"SewingFeatureLib Not Found.");

            entity.Name = command.Name;
            entity.Description = command.Description;
            entity.BuyerCode = command.BuyerCode;
            entity.BuyerName = command.BuyerName;
            entity.SubCategoryCode = command.SubCategoryCode;
            entity.SubCategoryName = command.SubCategoryName;
            entity.SewingComponentId = command.SewingComponentId;
            entity.LabourCost = command.LabourCost;
            entity.AllowedTime = command.AllowedTime;
            entity.TotalSMV = command.TotalSMV;
            entity.Deleted = command.Deleted;
            entity.IsActive = command.IsActive;
            entity.SewingFeatureLibBOLs = null;

            var deleteItems = await _bolRepository.GetListAsync(command.Id);
            var insertItems = command.SewingFeatureLibBOLs?.Select(x => new SewingFeatureLibBOL
            {
                SewingFeatureLibId = command.Id,
                SewingOperationLibId = x.SewingOperationLibId,
                Type = x.Type,
                LineNumber = x.LineNumber,
                Freq = x.Freq,
                SMV = x.SMV,
                AllowedTime = x.AllowedTime,
                MachineName = x.MachineName,
                RPM = x.RPM
            }).ToList();

            await _repository.UpdateSewingFeatureLibAsync(entity, insertItems, deleteItems);
            return new Response<int>(entity.Id);
        }
    }
}
