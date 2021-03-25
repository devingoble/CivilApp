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
    public class List : BaseAsyncEndpoint.WithRequest<List.JacketRequest>.WithResponse<IList<List.ListResponse>>
    {
        private readonly IAsyncRepository<Jacket> _repository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public List(IAsyncRepository<Jacket> repository, IMapper mapper, IMediator mediator)
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("/jackets")]
        [SwaggerOperation(
            Summary = "List all jackets",
            Description = "List all jackets with search, sort, and paging parameters",
            OperationId = "Jacket.List",
            Tags = new[] { "JacketEndpoint" })
        ]
        public override Task<ActionResult<IList<ListResponse>>> HandleAsync(JacketRequest query, CancellationToken cancellationToken = default)
        {
            
        }

        public class MappingProfile : Profile
        {
            public MappingProfile() => CreateMap<Jacket, JacketResponse>();
        }

        public record JacketRequest(string? JacketNumber, string? Defendant, string? Plaintiff, string? ReceivedFrom, string? ServeTo,
            string? ServeToAddress, string? CourtCaseNumber, string? CSPNumber, int Page, int PageSize, string SortBy, SortOrder SortOrder) : IRequest<ListResponse>;

        public record ListResponse(JacketResponse Jackets, int JacketCount, int CurrentPage, int PageCount);

        public record JacketResponse(string JacketNumber, DateTime ReceivedDate, string ReceivedFrom, string Defendant, string ServeTo,
            string Status, DateTime? ServiceDate, string ActualServeTo);

        public class JacketRequestHandler : IRequestHandler<JacketRequest, ListResponse>
        {
            private readonly IAsyncRepository<Jacket> _repository;

            public JacketRequestHandler(IAsyncRepository<Jacket> repository)
            {
                _repository = repository;
            }

            public Task<ListResponse> Handle(JacketRequest request, CancellationToken cancellationToken)
            {
                var filter = new JacketFilter(request.JacketNumber, request.Defendant, request.Plaintiff, request.ReceivedFrom, request.Page, request.PageSize, request.SortBy, request.SortOrder);

                
            }
        }

    }
}
