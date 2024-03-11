using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.AQLs
{
    public class UpdateAQLCommand : IRequest<Response<int>>
    {
        public int AQLVersionId { get; set; }
		public int LotSizeFrom { get; set; }
		public int LotSizeTo { get; set; }
		public int SampleSize { get; set; }
		public int? Accept { get; set; }
		public int? Reject { get; set; }
        public int Id { get; set; }
       
        public bool IsActive { set; get; }
    }
    public class UpdateAQLCommandHandler : IRequestHandler<UpdateAQLCommand, Response<int>>
    {
        private readonly IAQLRepository _repository;
        public UpdateAQLCommandHandler(IAQLRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateAQLCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"AQL Not Found.");
            entity.IsActive = command.IsActive;
            entity.AQLVersionId = command.AQLVersionId;
			entity.LotSizeFrom = command.LotSizeFrom;
			entity.LotSizeTo = command.LotSizeTo;
			entity.SampleSize = command.SampleSize;
			entity.Accept = command.Accept;
			entity.Reject = command.Reject;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
