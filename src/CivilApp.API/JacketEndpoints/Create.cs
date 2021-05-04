using Ardalis.ApiEndpoints;

using CivilApp.Core.Entities.JacketAggregate;
using CivilApp.Core.Interfaces;

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
    public class Create : BaseAsyncEndpoint.WithRequest<Create.CreateJacketRequest>.WithResponse<Create.CreateJacketResponse>
    {
        private readonly IMediator _mediator;

        public Create(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/jackets")]
        [SwaggerOperation(
            Summary = "Create a new jacket",
            Description = "Create a new jacket from scratch",
            OperationId = "Jacket.Create",
            Tags = new[] { "JacketEndpoint" })
        ]
        public async override Task<ActionResult<CreateJacketResponse>> HandleAsync(CreateJacketRequest request, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(request);
        }

        public record CreateJacketRequest() : IRequest<CreateJacketResponse>;

        public record CreateJacketResponse(int Id, int JacketYear, int JacketSequence);

        public class CreateJacketRequestHandler : IRequestHandler<CreateJacketRequest, CreateJacketResponse>
        {
            private readonly IAsyncRepository<Jacket> _repository;
            private readonly IJacketSequenceService _sequenceService;

            public CreateJacketRequestHandler(IAsyncRepository<Jacket> repository, IJacketSequenceService sequenceService)
            {
                _repository = repository;
                _sequenceService = sequenceService;
            }

            public async Task<CreateJacketResponse> Handle(CreateJacketRequest request, CancellationToken cancellationToken)
            {
                var newJacket = new Jacket();

                if (_sequenceService.NeedsSequenceReset())
                {
                    _sequenceService.ResetSequence();
                }

                var jacket = await _repository.AddAsync(newJacket, cancellationToken);

                return new CreateJacketResponse(jacket.Id, jacket.JacketYear, jacket.JacketSequence);
            }
        }
    }
}
