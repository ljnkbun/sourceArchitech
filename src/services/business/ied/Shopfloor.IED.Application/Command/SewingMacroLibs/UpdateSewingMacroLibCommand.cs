﻿using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingMacroLibBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingMacroLibs
{
    public class UpdateSewingMacroLibCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalBasicMinutes { get; set; }
        public decimal NoneMachineTime { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { set; get; }
        public virtual ICollection<SewingMacroLibBOLModel> SewingMacroLibBOLs { get; set; }
    }
    public class UpdateSewingMacroLibCommandHandler : IRequestHandler<UpdateSewingMacroLibCommand, Response<int>>
    {
        private readonly ISewingMacroLibRepository _repository;
        private readonly ISewingMacroLibBOLRepository _bolRepository;

        public UpdateSewingMacroLibCommandHandler(ISewingMacroLibRepository repository, ISewingMacroLibBOLRepository bolRepository)
        {
            _repository = repository;
            _bolRepository = bolRepository;
        }
        public async Task<Response<int>> Handle(UpdateSewingMacroLibCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"SewingMacroLib Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.Description = command.Description;
            entity.BundleTMU = command.BundleTMU;
            entity.MachineTMU = command.MachineTMU;
            entity.ManualTMU = command.ManualTMU;
            entity.NoneMachineTime = command.NoneMachineTime;
            entity.TotalBasicMinutes = command.TotalBasicMinutes;
            entity.Deleted = command.Deleted;
            entity.IsActive = command.IsActive;
            entity.SewingMacroLibBOLs = null;

            var deleteItems = await _bolRepository.GetListAsync(command.Id);                                                                                                           // || !command.ProductCategories.Any(v => v.Id == x.Id)).ToList();
            var insertItems = command.SewingMacroLibBOLs?.Select(x => new SewingMacroLibBOL
            {
                SewingMacroLibId = command.Id,
                SewingTaskLibId = x.SewingTaskLibId,
                LineNumber = x.LineNumber,
                Freq = x.Freq,
                TotalTMU = x.TotalTMU
            }).ToList();

            await _repository.UpdateSewingMacroLibAsync(entity, insertItems, deleteItems);
            return new Response<int>(entity.Id);
        }
    }
}
