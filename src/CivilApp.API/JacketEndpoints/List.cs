using Ardalis.ApiEndpoints;

using AutoMapper;

using CivilApp.Core.Entities.JacketAggregate;
using CivilApp.Core.Interfaces;
using CivilApp.Core.Specifications;
using CivilApp.Core.Specifications.Filters;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CivilApp.API.JacketEndpoints
{
    public class List : BaseAsyncEndpoint.WithRequest<List.JacketRequest>.WithResponse<List.ListResponse>
    {
        private readonly IMediator _mediator;

        public List(IAsyncRepository<Jacket> repository, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/jackets")]
        [SwaggerOperation(
            Summary = "List all jackets",
            Description = "List all jackets with search, sort, and paging parameters",
            OperationId = "Jacket.List",
            Tags = new[] { "JacketEndpoint" })
        ]
        public async override Task<ActionResult<ListResponse>> HandleAsync(JacketRequest query, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(query);
        }

        public class MappingProfile : Profile
        {
            public MappingProfile() => CreateMap<Jacket, JacketResponse>();
        }

        public record JacketRequest(int? JacketYear, int? JacketSequence, string? Defendant, string? Plaintiff, string? ReceivedFrom, string? ServeTo,
            string? ServeToAddress, string? CourtCaseNumber, string? CSPNumber, int Page, int PageSize, List<SortField> SortFields) : IRequest<ListResponse>;

        public record ListResponse(IReadOnlyList<JacketResponse> Jackets, int JacketCount, int CurrentPage, int PageCount);

        public record JacketResponse(string JacketNumber, DateTime ReceivedDate, string ReceivedFrom, string Defendant, string ServeTo,
            string Status, DateTime? ServiceDate, string ActualServeTo);

        public class JacketRequestHandler : IRequestHandler<JacketRequest, ListResponse>
        {
            private readonly IAsyncRepository<Jacket> _repository;
            private readonly IMapper _mapper;

            public JacketRequestHandler(IAsyncRepository<Jacket> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<ListResponse> Handle(JacketRequest request, CancellationToken cancellationToken)
            {
                var filter = new JacketFilter(request.JacketYear, request.JacketSequence, request.Defendant, request.Plaintiff, request.ReceivedFrom, request.Page, request.PageSize, request.SortFields);
                var spec = new JacketSpecification(filter);

                var totalJackets = await _repository.CountAsync(spec, cancellationToken);
                var pageCount = (int)Math.Ceiling((decimal)totalJackets / request.PageSize);
                var jackets = await _repository.ListAsync(spec, cancellationToken);
                
                var response = new ListResponse(jackets.Select(_mapper.Map<JacketResponse>).ToList(), totalJackets, request.Page, pageCount);

                return response;
            }
        }
    }
}
