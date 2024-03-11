using MediatR;
using NPOI.Util;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.MergeSplitPORs
{
    public class DeleteMergeSplitPORCommand : IRequest<Response<int>>
    {
        public int PorId { get; set; }
    }
    public class DeleteMergeSplitPORCommandHandler : IRequestHandler<DeleteMergeSplitPORCommand, Response<int>>
    {
        private readonly IPORRepository _porRepository;
        private readonly IMergeSplitPORRepository _mergeSplitPORRepository;
        private readonly IMergeSplitPorDetailRepostiry _mergeSplitPorDetailRepostiry;
        public DeleteMergeSplitPORCommandHandler(IPORRepository porRepository,
           IMergeSplitPORRepository mergeSplitPORRepository,
           IMergeSplitPorDetailRepostiry mergeSplitPorDetailRepostiry)
        {
            _porRepository = porRepository;
            _mergeSplitPORRepository = mergeSplitPORRepository;
            _mergeSplitPorDetailRepostiry = mergeSplitPorDetailRepostiry;
        }
        public async Task<Response<int>> Handle(DeleteMergeSplitPORCommand request, CancellationToken cancellationToken)
        {
            var por = await _porRepository.GetByIdAsync(request.PorId);
            if(por == null) return new($"POR Not Found.");
            var lstPorDetail = new List<PORDetail>();
            var lstPor = new List<POR>();

            // Update POR
            foreach (var porItem in por.ToMergeSplitPORs)
            {
                var porUpdate = await _porRepository.GetByIdAsync(porItem.FromPORId);
                porUpdate.RemainingQuantity += por.ToMergeSplitPORs.FirstOrDefault(x => x.FromPORId == porUpdate.Id).Quantity;
                lstPorDetail.AddRange(porUpdate.PORDetails.ToList());
                lstPor.Add(porUpdate);
            }

            // Get Merge POR Detail delete
            var deleteMergePorDetails = await _mergeSplitPorDetailRepostiry.GetByToPorDetailIds(por.PORDetails.Select(x => x.Id).ToList());

            var porDetailDelete = por.PORDetails.Copy();
            foreach (var item in porDetailDelete)
            {
                item.ToMergeSplitPorDetails = deleteMergePorDetails.Where(x => x.ToPorDetailId == item.Id).ToList();
            }

            // Update POR Detail
            foreach (var porDetailItem in lstPorDetail)
            {
                porDetailItem.RemainingQuantity += porDetailDelete.FirstOrDefault(x => x.Color.Contains(porDetailItem.Color) && x.Size.Contains(porDetailItem.Size))
                                                   .ToMergeSplitPorDetails.FirstOrDefault(y => y.FromPorDetailId == porDetailItem.Id).Quantity;
            }

            // Delete Merge/Split POR
            await _mergeSplitPORRepository.DeleteMergeSplitPorAsync(lstPor, lstPorDetail, deleteMergePorDetails, por);

            return new Response<int>(por.Id);
        }
    }
}
