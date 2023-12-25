using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingMacroBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingMacros
{
    public class UpdateSewingMacroCommand : IRequest<Response<int>>
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
        public virtual ICollection<SewingMacroBOLModel> SewingMacroBOLs { get; set; }
    }
    public class UpdateSewingMacroCommandHandler : IRequestHandler<UpdateSewingMacroCommand, Response<int>>
    {
        private readonly ISewingMacroRepository _repository;
        private readonly IMapper _mapper;

        public UpdateSewingMacroCommandHandler(ISewingMacroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateSewingMacroCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"SewingMacro Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.Description = command.Description;
            entity.BundleTMU = command.BundleTMU;
            entity.ManualTMU = command.ManualTMU;
            entity.ManualTMU = command.ManualTMU;
            entity.TotalBasicMinutes = command.TotalBasicMinutes;
            entity.NoneMachineTime = command.NoneMachineTime;
            entity.Deleted = command.Deleted;
            entity.IsActive = command.IsActive;
            entity.SewingMacroBOLs = null;

            var newSewingMacroBOLs = _mapper.Map<List<SewingMacroBOL>>(command.SewingMacroBOLs);
            foreach (var item in newSewingMacroBOLs ?? Enumerable.Empty<SewingMacroBOL>())
            {
                item.SewingMacroId = entity.Id;
            }

            await _repository.UpdateSewingMacroAsync(entity, newSewingMacroBOLs);
            return new Response<int>(entity.Id);
        }
    }
}
