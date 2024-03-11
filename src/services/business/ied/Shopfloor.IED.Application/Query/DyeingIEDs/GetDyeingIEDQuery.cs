using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingIEDs;
using Shopfloor.IED.Application.Models.KnittingIEDs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingIEDs
{
    public class GetDyeingIEDQuery : IRequest<Response<DyeingIED>>
    {
        public int Id { get; set; }
    }

    public class GetDyeingIEDQueryHandler : IRequestHandler<GetDyeingIEDQuery, Response<DyeingIED>>
    {
        private readonly IDyeingIEDRepository _repository;
        public GetDyeingIEDQueryHandler(IDyeingIEDRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<DyeingIED>> Handle(GetDyeingIEDQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) return new($"DyeingIED Not Found (Id:{query.Id}).");
            return new Response<DyeingIED>(entity);
        }
    }
}