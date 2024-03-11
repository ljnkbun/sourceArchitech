using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.RequestDivisionFiles;
using Shopfloor.IED.Application.Command.RequestDivisionProcesses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestDivisions
{
    public class UpdateRequestDivisionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int DivisionId { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public int LineNumber { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string Remark { get; set; }
        public bool IsActive { set; get; }
        public ICollection<UpdateRequestDivisionProcessCommand> RequestDivisionProcesses { get; set; }
        public ICollection<UpdateRequestDivisionFileCommand> RequestDivisionFiles { get; set; }
    }
    public class UpdateRequestDivisionCommandHandler : IRequestHandler<UpdateRequestDivisionCommand, Response<int>>
    {
        private readonly IRequestDivisionRepository _repository;
        public UpdateRequestDivisionCommandHandler(IRequestDivisionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateRequestDivisionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"RequestDivision Not Found.");

            entity.DivisionId = command.DivisionId;
            entity.DivisionCode = command.DivisionCode;  
            entity.DivisionName = command.DivisionName;
            entity.LineNumber = command.LineNumber;
            entity.ExpectedDate = command.ExpectedDate;
            entity.Remark = command.Remark;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
