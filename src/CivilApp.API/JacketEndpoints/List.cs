using Ardalis.ApiEndpoints;

using AutoMapper;

using CivilApp.Core.Entities.JacketAggregate;
using CivilApp.Core.Interfaces;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CivilApp.API.JacketEndpoints
{
    public class List : BaseAsyncEndpoint.WithRequest<JacketRequest>.WithResponse<IList<JacketResponse>>
    {
        private readonly IAsyncRepository<Jacket> _repository;
        private readonly IMapper _mapper;

        public List(IAsyncRepository<Jacket> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override Task<ActionResult<IList<JacketResponse>>> HandleAsync(JacketRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
